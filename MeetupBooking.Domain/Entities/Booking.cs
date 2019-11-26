namespace MeetupBooking.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public int RoomId { get; set; }

        public Room Room { get; set; }

        public int MeetupId { get; set; }

        public Meetup Meetup { get; set; }
    }
}
