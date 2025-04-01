using Microsoft.EntityFrameworkCore;
using myapp.Data;
using myapp.models;

namespace myapp.Repositories{
    public class ClassRepository : IClassRepository
    {
        private readonly StudentContext _context;

        public ClassRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<Class> GetByIdAsync(int id)
        {
            return await _context.Class.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _context.Class.ToListAsync();
        }

        public async Task<Class> CreateAsync(Class Class)
        {
            _context.Class.Add(Class);
            await _context.SaveChangesAsync();
            return Class;
        }

        public async Task UpdateAsync(Class Class)
        {
            _context.Class.Update(Class);
            _context.Entry(Class).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Class = await GetByIdAsync(id);
            if (Class != null)
            {
                _context.Class.Remove(Class);
                await _context.SaveChangesAsync();
            }
        }
    }
}