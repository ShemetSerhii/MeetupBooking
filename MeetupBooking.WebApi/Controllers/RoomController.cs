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

            var booking = _mappingService.Map<BookingModel, BookingDto>(model);

            await _roomService.Book(meetupId, booking);

            return Ok();

        }

        [HttpPut]
        public void EditBooking()
        { }

        [HttpDelete]
        public async Task<IActionResult> CancelBooking([FromQuery] int roomId, [FromQuery]int meetupId)
        {

                await _roomService.CancelBooking(roomId, meetupId);

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