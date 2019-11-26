using System;

namespace MeetupBooking.Services.Models
{
    public class BookingDto
    {
        public int RoomId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
