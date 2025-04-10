using Domain.Entities;

namespace Domain.Interfaces;

public interface IDepartmentRepository
{
    Task<IEnumerable<Departments>> GetAllAsync();
    Task<Departments> GetByIdAsync(Guid id);
    Task AddAsync(Departments department);
    Task UpdateAsync(Departments department);
    Task DeleteAsync(Guid id);
}