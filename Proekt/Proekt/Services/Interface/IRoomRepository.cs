using Proekt.Models;
using Proekt.Models.DTO;

namespace Proekt.Services.Interface
{
    public interface IRoomRepository
    {
        Task<Room> GetByIdAsync(int id);
        Task<List<Room>> GetAllAsync();
      
        Task<Room> UpdateAsync(Room room);
        Task DeleteAsync(int id);
        Task AddAsync(RoomDto room);
    }
}
