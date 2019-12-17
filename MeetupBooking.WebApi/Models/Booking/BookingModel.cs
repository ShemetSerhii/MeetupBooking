using System;
using System.ComponentModel.DataAnnotations;

namespace MeetupBooking.WebApi.Models.Booking
{
    public class BookingModel
    {
        [Required]
        public int RoomId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFrom { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTo { get; set; }
    }
}
