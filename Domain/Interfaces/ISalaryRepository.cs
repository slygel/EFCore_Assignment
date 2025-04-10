using Domain.Entities;

namespace Domain.Interfaces;

public interface ISalaryRepository
{
    Task<IEnumerable<Salaries>> GetAllAsync();
    Task<Salaries> GetByIdAsync(Guid id);
    Task AddAsync(Salaries salaries);
    Task UpdateAsync(Salaries salaries);
    Task DeleteAsync(Guid id);
}