using MeetupBooking.Common.Interfaces;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Interfaces;
using MeetupBooking.WebApi.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MeetupBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMeetupService _meetupService;
        private readonly IMappingService _mappingService;

        public AccountController(IUserService userService, IMeetupService meetupService, IMappingService mappingService)
        {
            _userService = userService;
            _meetupService = meetupService;
            _mappingService = mappingService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var user = await _userService.GetUser(User.Identity.Name);

            var viewModel = _mappingService.Map<User, AccountViewModel>(user);

            var participant = await _meetupService.Find(m => m.Participants.Select(x => x.Id).Contains(user.Id));

            var owners = await _meetupService.Find(m => m.OwnerId == user.Id);

            viewModel.MeetupsId = participant.Select(x => x.Id);
            viewModel.OwnerMeetups = owners.Select(x => x.Id);

            return Ok(viewModel);
        }

        [HttpPost("/login")]
        public async Task Login(LoginModel model)
        {
           var user = await _userService.GetUser(model.Email, model.Password);

            await Authenticate(user);           
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = _mappingService.Map<RegisterModel, User>(model);

            await _userService.Register(user);

            return Ok();
        }

        [Authorize]
        [HttpPut("/edit")]
        public async Task<IActionResult> Edit(int id, RegisterModel model)
        {
            var user = _mappingService.Map<RegisterModel, User>(model);

            user.Id = id;

            await _userService.Update(user);

            return Ok();
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}