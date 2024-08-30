using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proekt.Models.DTO;
using Proekt.Services.Interface;

namespace Proekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
           _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDto createRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room = new RoomDto
            {
               Number = createRoomDto.Number,
               Floor = createRoomDto.Floor,
               Type = createRoomDto.Type,

            };

            await _roomRepository.AddAsync(room);
            return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] UpdateRoomDto roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRoom = await _roomRepository.GetByIdAsync(id);
            if (existingRoom == null)
            {
                return NotFound();
            }

            existingRoom.Number = roomDto.Number;
            existingRoom.Floor = roomDto.Floor;
            existingRoom.Type = roomDto.Type;

            await _roomRepository.UpdateAsync(existingRoom);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomRepository.DeleteAsync(id);
            return NoContent();
        }


    }
}
