using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces;

public interface ISalaryService
{
    Task<IEnumerable<SalaryDto>> GetAllAsync();
    Task<SalaryDto> GetByIdAsync(Guid id);
    Task<SalaryDto> CreateAsync(SalaryRequestDto salary);
    Task UpdateAsync(Guid id, SalaryRequestDto salary);
    Task DeleteAsync(Guid id);
}