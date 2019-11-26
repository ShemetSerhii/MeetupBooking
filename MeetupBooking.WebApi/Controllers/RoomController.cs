using MeetupBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetupBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public void GetRooms()
        { 

        }


        [HttpPost]
        public void Book()
        { }

        [HttpPut]
        public void EditBooking()
        { }

        [HttpDelete]
        public void CancelBooking()
        { }
    }
}