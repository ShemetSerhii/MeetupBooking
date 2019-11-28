using MeetupBooking.WebGrabberFramework;
using System.Threading.Tasks;
using static MeetupBooking.WebGrabberFramework.TableAnalyzer;

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

        public async Task Start(Send send)
        {
            grabber.NavigateTo(_startUrl);
            grabber.FindTable();

            await Synchronize(send);
        }

        private async Task Synchronize(Send send)
        {
            var links = grabber.GetLinks();

            await grabber.OpenSheduleByLink(links, send);
        }
    }
}
