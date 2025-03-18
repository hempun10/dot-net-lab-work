using myapp.models;

namespace myapp.Repositories
{
    public interface IHotelRepository
    {
        Task<Hotel> GetByIdAsync(int id);
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel> CreateAsync(Hotel hotel);
        Task UpdateAsync(Hotel hotel);
        Task DeleteAsync(int id);
    }
}