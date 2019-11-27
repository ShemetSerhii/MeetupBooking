using MeetupBooking.Common.Interfaces;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Interfaces;
using MeetupBooking.Services.Models;
using MeetupBooking.WebApi.Models.Meetup;
using MeetupBooking.WebApi.Models.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetupBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMeetupService _meetupService;
        private readonly IMappingService _mappingService;

        public RoomController(IRoomService roomService, IMeetupService meetupService, IMappingService mappingService)
        {
            _roomService = roomService;
            _meetupService = meetupService;
            _mappingService = mappingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomService.GetRooms();

            var roomsModel = _mappingService.Map<IEnumerable<Room>, List<RoomViewModel>>(rooms);

            return Ok(roomsModel);
        }


        [HttpPost]
        public async Task<IActionResult> Book(int meetupId, BookingModel model)
        { 
            if (await IsOwner(meetupId))
            {
                var booking = _mappingService.Map<BookingModel, BookingDto>(model);

                return Ok();
            }

            return Forbid();
        }

        [HttpPut]
        public void EditBooking()
        { }

        [HttpDelete]
        public async Task<IActionResult> CancelBooking(int roomId, int meetupId)
        {
            if (await IsOwner(meetupId))
            {
                await _roomService.CancelBooking(roomId, meetupId);

                return Ok();
            }

            return Forbid();
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