using Microsoft.EntityFrameworkCore;
using Proekt.Data;
using Proekt.Models;
using Proekt.Models.DTO;
using Proekt.Services.Interface;

namespace Proekt.Services.Repos
{
    public class RoomRepository : IRoomRepository
    {
        readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Room> GetByIdAsync(int id)
        {
            return await _context.Room.FindAsync(id);
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Room.ToListAsync();
        }

        public async Task AddAsync(RoomDto room)
        {
            var Room = new Room
            {
                Number = room.Number,
                Floor = room.Floor,
                Type = room.Type,
            };

            await _context.Room.AddAsync(Room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> UpdateAsync(Room room)
        {
            _context.Room.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room != null)
            {
                _context.Room.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }
}
