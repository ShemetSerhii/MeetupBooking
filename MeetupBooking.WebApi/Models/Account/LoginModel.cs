﻿using System.ComponentModel.DataAnnotations;

namespace MeetupBooking.WebApi.Models.Account
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
