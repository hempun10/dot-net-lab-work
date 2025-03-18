using Microsoft.EntityFrameworkCore;
using myapp.Data;
using myapp.models;

namespace myapp.Repositories{
    public class HotelRepository : IHotelRepository
    {
        private readonly StudentContext _context;

        public HotelRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> CreateAsync(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task UpdateAsync(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotel = await GetByIdAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }
    }
}