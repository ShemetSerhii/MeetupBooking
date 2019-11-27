using MeetupBooking.WebGrabberFramework;
using System.Threading.Tasks;

namespace MeetupBooking.SynchronizingWebJob
{
    public class Synchronizer
    {
        private readonly WebGrabber grabber;
        private readonly string _startUrl = "http://cist.nure.ua/ias/app/tt/f?p=778:40:3771911341850997";

        public Synchronizer()
        {
            grabber = new WebGrabber();
        }

        public async Task Start()
        {
            grabber.NavigateTo(_startUrl);
            grabber.FindTable();

            await Synchronize();
        }

        private async Task Synchronize()
        {
            var links = grabber.GetLinks();

            await grabber.OpenSheduleByLink(links);
        }
    }
}
