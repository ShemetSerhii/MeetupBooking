using System.ComponentModel.DataAnnotations;

namespace MeetupBooking.WebApi.Models.Meetup
{
    public class MeetupEditModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }
    }
}
