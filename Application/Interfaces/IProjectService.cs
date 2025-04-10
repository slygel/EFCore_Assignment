using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllAsync();
    Task<ProjectDto> GetByIdAsync(Guid id);
    Task<ProjectDto> CreateAsync(ProjectRequestDto project);
    Task UpdateAsync(Guid id, ProjectRequestDto project);
    Task DeleteAsync(Guid id);
}