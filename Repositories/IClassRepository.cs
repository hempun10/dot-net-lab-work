using myapp.models;

namespace myapp.Repositories
{
    public interface IClassRepository
    {
        Task<Class> GetByIdAsync(int id);
        Task<IEnumerable<Class>> GetAllAsync();
        Task<Class> CreateAsync(Class Class);
        Task UpdateAsync(Class Class);
        Task DeleteAsync(int id);
    }
}