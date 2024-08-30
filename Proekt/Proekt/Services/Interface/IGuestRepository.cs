using Proekt.Models;
using Proekt.Models.DTO;

namespace Proekt.Services.Interface
{
    public interface IGuestRepository
    {
        Task<Guest> GetByIdAsync(int id);
        Task<List<Guest>> GetAllAsync();
        Task AddAsync(CreateGuestDto createGuestDto);
        Task<Guest> UpdateAsync(Guest Guest);
        Task DeleteAsync(int id);

    }
}
