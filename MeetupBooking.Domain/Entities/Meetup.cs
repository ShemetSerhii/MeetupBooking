using System.Collections.Generic;

namespace MeetupBooking.Domain.Entities
{
    public class Meetup : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Booking> Rooms { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
