using Microsoft.AspNetCore.Mvc;
using myapp.models;

namespace myapp.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> CreateAsync(Student stduent);
        Task UpdateAsync(Student stduent);
        Task DeleteAsync(int id);
    }
}