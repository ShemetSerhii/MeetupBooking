using MeetupBooking.Common.Interfaces;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Interfaces;
using MeetupBooking.Services.Models;
using MeetupBooking.WebApi.Models.Meetup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeetupBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        private readonly IMeetupService _meetupService;
        private readonly IUserService _userService;
        private readonly IMappingService _mapperService; 

        public MeetupController(IMeetupService meetupService, IUserService userService, IMappingService mappingService)
        {
            _meetupService = meetupService;
            _userService = userService;
            _mapperService = mappingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var meetup = await _meetupService.Get(id);

            var meetupModel = _mapperService.Map<Meetup, MeetupViewModel>(meetup);

            return Ok(meetupModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MeetupCreateModel model)
        {
            var meetup = _mapperService.Map<MeetupCreateModel, MeetupDtoModel>(model);

            var user = await _userService.GetUser(User.Identity.Name);

            meetup.OwnerId = user.Id;
            meetup.Owner = user;

            await _meetupService.CreateAsync(meetup);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] MeetupEditModel model)
        {
            var meetup = await _meetupService.Get(id);

            meetup.Name = model.Name;
            meetup.Description = model.Description;

            await _meetupService.UpdateAsync(meetup);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _meetupService.Delete(id);

            return Ok();
        }
    }
}