using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces;

public interface IProjectEmployeeService
{
    Task<IEnumerable<ProjectEmployeeDto>> GetAllAsync();
    Task<ProjectEmployeeDto> GetByIdsAsync(Guid projectId, Guid employeeId);
    Task<ProjectEmployeeDto> CreateAsync(ProjectEmployeeRequestDto projectEmployee);
    Task UpdateAsync(Guid projectId, Guid employeeId, UpdateProjectEmployeeDto projectEmployee);
    Task DeleteAsync(Guid projectId, Guid employeeId);
}