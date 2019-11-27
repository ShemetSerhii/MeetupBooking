using System.Collections.Generic;

namespace MeetupBooking.WebApi.Models.Meetup
{
    public class MeetupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int OwnerId { get; set; }

        public ICollection<int> Rooms { get; set; }

        public ICollection<int> Participants { get; set; }
    }
}
