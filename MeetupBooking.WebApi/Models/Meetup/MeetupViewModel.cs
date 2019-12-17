using MeetupBooking.WebApi.Models.Room;
using System.Collections.Generic;

namespace MeetupBooking.WebApi.Models.Meetup
{
    public class MeetupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string OwnerName { get; set; }

        public ICollection<RoomViewModel> Rooms { get; set; }

        public ICollection<ParticipantViewModel> Participants { get; set; }
    }
}
