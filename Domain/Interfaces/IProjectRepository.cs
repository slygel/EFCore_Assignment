using Domain.Entities;

namespace Domain.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Projects>> GetAllAsync();
    Task<Projects> GetByIdAsync(Guid id);
    Task AddAsync(Projects projects);
    Task UpdateAsync(Projects projects);
    Task DeleteAsync(Guid id);
}