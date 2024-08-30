using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proekt.Models.DTO;
using Proekt.Services.Interface;

namespace Proekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;
        public GuestController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGuests()
        {
            var rooms = await _guestRepository.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuest(int id)
        {
            var guest = await _guestRepository.GetByIdAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] CreateGuestDto guestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _guestRepository.AddAsync(guestDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] UpdateGuestDto guestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingGuest = await _guestRepository.GetByIdAsync(id);
            if (existingGuest == null)
            {
                return NotFound();
            }

            existingGuest.FirstName = guestDto.FirstName;
            existingGuest.LastName = guestDto.LastName;
            existingGuest.DOB = guestDto.DOB;
            existingGuest.Address = guestDto.Address;
            existingGuest.CheckInDate = guestDto.CheckInDate;
            existingGuest.CheckOutDate = guestDto.CheckOutDate;
            existingGuest.RoomId = guestDto.RoomId;


            await _guestRepository.UpdateAsync(existingGuest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _guestRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
