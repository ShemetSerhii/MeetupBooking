using System;
using System.Threading.Tasks;

namespace MeetupBooking.SynchronizingWebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var sync = new Synchronizer();

            Task.WaitAll(sync.Start(Send));
        }

        public static void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
