using System.Collections.Generic;

namespace MeetupBooking.Domain.Entities
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Booking> Meetups { get; set; }
    }
}
