using Domain.Entities;

namespace Domain.Interfaces;

public interface IProjectEmployeeRepository
{
    Task<IEnumerable<ProjectEmployee>> GetAllAsync();
    Task<ProjectEmployee> GetByIdAsync(Guid projectId, Guid employeeId);
    Task AddAsync(ProjectEmployee projectEmployee);
    Task UpdateAsync(ProjectEmployee projectEmployee);
    Task DeleteAsync(Guid projectId, Guid employeeId);
}