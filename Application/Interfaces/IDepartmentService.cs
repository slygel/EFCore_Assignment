using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDto>> GetAllAsync();
    Task<DepartmentDto> GetByIdAsync(Guid id);
    Task<DepartmentDto> CreateAsync(DepartmentRequestDto department);
    Task UpdateAsync(Guid id, DepartmentRequestDto department);
    Task DeleteAsync(Guid id);
}