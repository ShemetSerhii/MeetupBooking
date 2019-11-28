﻿using MeetupBooking.WebApi.Models.Booking;
using System.Collections.Generic;

namespace MeetupBooking.WebApi.Models.Meetup
{
    public class MeetupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int OwnerId { get; set; }

        public IEnumerable<BookingViewModel> Rooms { get; set; }

        public IEnumerable<int> Participants { get; set; }
    }
}
