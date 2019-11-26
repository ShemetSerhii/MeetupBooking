using System.Collections.Generic;

namespace MeetupBooking.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Participant> Meetups { get; set; }
    }
}
