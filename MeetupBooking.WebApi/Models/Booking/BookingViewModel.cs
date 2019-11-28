using System;

namespace MeetupBooking.WebApi.Models.Booking
{
    public class BookingViewModel
    {
        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public DateTime TimeFrom { get; set; }

        public DateTime TimeTo { get; set; }
    }
}
