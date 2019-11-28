using MeetupBooking.WebApi.Models.Booking;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetupBooking.WebApi.Models.Meetup
{
    public class MeetupCreateModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public ICollection<BookingModel> Bookings { get; set; }

        public ICollection<int> Participants { get; set; }
    }
}
