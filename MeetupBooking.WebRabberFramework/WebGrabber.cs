using MeetupBooking.DAL.Context;
using MeetupBooking.Domain.Entities;
using MeetupBooking.WebGrabberFramework.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupBooking.WebGrabberFramework
{
    public class WebGrabber
    {
        private readonly IWebDriver _driver;
        private MeetupBookingDbContext _context;

        public WebGrabber()
        {
            _driver = new ChromeDriver(Directory.GetCurrentDirectory());
            var optionsBuilder = new DbContextOptionsBuilder<MeetupBookingDbContext>()
                    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MeetupBooking;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _context = new MeetupBookingDbContext(optionsBuilder.Options);
        }

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void FindTable()
        {
            var table = _driver.FindElement(By.ClassName("htmldbTabbedNavigationList"));

            var tab = table.FindElements(By.CssSelector("td[valign=bottom]")).Last();

            tab.Click();
        }

        public IEnumerable<IWebElement> GetLinks()
        {
            var table = _driver.FindElement(By.ClassName("t13Standard"));

            return table.FindElements(By.TagName("a"));
        }

        public async Task OpenSheduleByLink(IEnumerable<IWebElement> links)
        {
            foreach (var link in links)
            {
                await OpenSheduleByLink(link);
            }
        }

        private async Task OpenSheduleByLink(IWebElement link)
        {
            link.Click();

            await CreateRoom(link.Text);

            var buttom = _driver.FindElement(By.CssSelector("td[class=C]"));
            buttom.Click();

            var winHandleBefore = _driver.CurrentWindowHandle;

            _driver.SwitchTo().Window(_driver.WindowHandles[1]);

            var tableAnalyzer = new TableAnalyzer(_driver);

            var results = tableAnalyzer.Process();

            _driver.Close();

            _driver.SwitchTo().Window(winHandleBefore);


            var div = _driver.FindElement(By.Id("CHOISE_AUDS"));
            div.FindElement(By.TagName("a")).Click();

            await SyncWithDb(link.Text, results);
        }

        private async Task SyncWithDb(string roomName, IEnumerable<ResultModel> results)
        {
            var roomSet = _context.Set<Room>();

            var room = await roomSet.FirstOrDefaultAsync(r => r.Name == roomName);

            var meetupSet = _context.Set<Meetup>();
            await meetupSet.AddAsync(new Meetup
            {
                Name = "Lecture",
                Description = "Lecture",
                OwnerId = 1,
                Rooms = results.Select(r => new Booking
                {
                    RoomId = room.Id,
                    DateFrom = DateTime.Parse($"{r.StartTime} {r.Date}"),
                    DateTo = DateTime.Parse($"{r.EndTime} {r.Date}")
                }).ToList()
            });
        }

        private async Task CreateRoom(string name)
        {
            var set = _context.Set<Room>();

            await set.AddAsync(new Room { Name = name });

            await _context.SaveChangesAsync();
        }
    }
}
