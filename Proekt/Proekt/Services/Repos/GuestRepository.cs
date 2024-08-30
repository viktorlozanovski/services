using Microsoft.EntityFrameworkCore;
using Proekt.Data;
using Proekt.Models;
using Proekt.Models.DTO;
using Proekt.Services.Interface;

namespace Proekt.Services.Repos
{
    public class GuestRepository : IGuestRepository
    {
        readonly ApplicationDbContext _context;
        public GuestRepository(ApplicationDbContext context) 
        {
            _context = context;                 
        }
        public async Task<Guest> GetByIdAsync(int id)
        {
            return await _context.Guest.FindAsync(id);
        }

        public async Task<List<Guest>> GetAllAsync()
        {
            return await _context.Guest.ToListAsync();
        }

        public async Task AddAsync(CreateGuestDto createGuestDto)
        {
            var Guest = new Guest
            {
                FirstName = createGuestDto.FirstName,
                LastName = createGuestDto.LastName,
                DOB = createGuestDto.DOB,
                Address = createGuestDto.Address,
                Nationality = createGuestDto.Nationality,
                CheckInDate = createGuestDto.CheckInDate,
                CheckOutDate = createGuestDto.CheckOutDate,
                RoomId = createGuestDto.RoomId,

            };

            await _context.Guest.AddAsync(Guest);
            await _context.SaveChangesAsync();
        }


        public async Task<Guest> UpdateAsync(Guest Guest)
        {
            _context.Guest.Entry(Guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Guest;
        }

        public async Task DeleteAsync(int id)
        {
            var guest = await _context.Guest.FindAsync(id);
            if (guest != null)
            {
                _context.Guest.Remove(guest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
