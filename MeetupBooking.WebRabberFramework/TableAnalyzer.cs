using MeetupBooking.WebGrabberFramework.Models;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetupBooking.WebGrabberFramework
{
    public class TableAnalyzer
    {
        private readonly IWebDriver _driver;
        private IList<IWebElement> _tdsHeader;
        private IList<ResultModel> _results;

        public TableAnalyzer(IWebDriver driver)
        {
            _driver = driver;
            _results = new List<ResultModel>();
        }

        public IEnumerable<ResultModel> Process()
        {   
            Analyzing();


            return _results;
        }

        private void Analyzing()
        {
            var tbody = _driver.FindElement(By.ClassName("MainTT"));

            var trs = tbody.FindElements(By.TagName("tr"));

            _tdsHeader = trs[1].FindElements(By.TagName("td"));

            AnalyzeTrs(trs);
        }

        private void AnalyzeTrs(IList<IWebElement> trs)
        {
            for (var index = 2; index < trs.Count; index++)
            {
                var tds = trs[index].FindElements(By.TagName("td"));
                AnalyzeTds(tds);
            }
        }

        private void AnalyzeTds(IList<IWebElement> tds)
        {
            for (var index = 2; index < tds.Count; index++)
            {
                if (IsValidatTd(tds[index]))
                {
                    _results.Add(MakeResult(tds, index));
                }
            }
        }

        private bool IsValidatTd(IWebElement td)
        {
            var atr = td.Text;
            
            return atr == "X";
        }

        private ResultModel MakeResult(IList<IWebElement> tds, int index)
        {
            var times = tds[1].Text.Split(" ");

            var result = new ResultModel
            {
                StartTime = times[0],
                EndTime = times[1],
                Date = _tdsHeader[index].Text
            };

            return result;
        }
    }
}
