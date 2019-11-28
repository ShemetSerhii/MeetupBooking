using MeetupBooking.Common.Interfaces;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Interfaces;
using MeetupBooking.Services.Models;
using MeetupBooking.WebApi.Models.Booking;
using MeetupBooking.WebApi.Models.Meetup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetupBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        private readonly IMeetupService _meetupService;
        private readonly IMappingService _mapperService; 

        public MeetupController(IMeetupService meetupService, IMappingService mappingService)
        {
            _meetupService = meetupService;
            _mapperService = mappingService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var meetups = await _meetupService.GetAll();

            var meetupModel = _mapperService.Map<IEnumerable<Meetup>, List<MeetupViewModelList>>(meetups);

            return Ok(meetupModel);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var meetup = await _meetupService.Get(id);
            var bookings = await _meetupService.GetBookings(id);

            if (meetup == null) return NotFound();

            var meetupModel = _mapperService.Map<Meetup, MeetupViewModel>(meetup);
            var bookingsModel = _mapperService.Map<IEnumerable<Booking>, List<BookingViewModel>>(bookings);

            meetupModel.Rooms = bookingsModel;

            return Ok(meetupModel);
        }

        [HttpPost("{meetupId}/invitate/{userId}")]
        public async Task<IActionResult> Invitate(int meetupId, int userId)
        {
            if (await IsOwner(meetupId))
            {
                await _meetupService.Invitate(meetupId, userId);
            }

            return Forbid();
        }

        [HttpPost("{meetupId}/invitate")]
        public async Task<IActionResult> Invitate(int meetupId, int[] usersId)
        {
            if (await IsOwner(meetupId))
            {
                await _meetupService.Invitate(meetupId, usersId);
            }

            return Forbid();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MeetupCreateModel model)
        {
            var meetup = _mapperService.Map<MeetupCreateModel, MeetupDtoModel>(model);

            await _meetupService.CreateAsync(meetup, User.Identity.Name);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] MeetupEditModel model)
        {
            var meetup = await _meetupService.Get(id);

            if (meetup == null) return NotFound();

            meetup.Name = model.Name;
            meetup.Description = model.Description;

            await _meetupService.UpdateAsync(meetup);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _meetupService.Delete(id);

            return Ok();
        }

        private async Task<bool> IsOwner(int meetupId)
        {
            var meetup = await _meetupService.Get(meetupId);

            if (meetup.Owner.Email == User.Identity.Name)
            {
                return true;
            }

            return false;
        }
    }
}