using System.Collections.Generic;

namespace MeetupBooking.WebApi.Models.Account
{
    public class AccountViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> MeetupsId { get; set; }

        public IEnumerable<int> OwnerMeetups { get; set; }
    }
}
