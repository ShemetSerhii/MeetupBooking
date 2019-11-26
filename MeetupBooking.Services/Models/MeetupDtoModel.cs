using MeetupBooking.Domain.Entities;
using System.Collections.Generic;

namespace MeetupBooking.Services.Models
{
    public class MeetupDtoModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BookingDto> Bookings { get; set; }

        public ICollection<int> Participants { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
