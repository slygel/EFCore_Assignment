using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto> GetByIdAsync(Guid id);
    Task<EmployeeDto> CreateAsync(EmployeeRequestDto employee);
    Task UpdateAsync(Guid id, EmployeeRequestDto employee);
    Task DeleteAsync(Guid id);
    
    Task<IEnumerable<EmployeeDepartmentDto>> GetAllWithDepartmentAsync();
    Task<IEnumerable<EmployeeProjectDto>> GetAllWithProjectsAsync();
    Task<IEnumerable<EmployeeSalaryDto>> GetEmployeesBySalaryAndDateRawSqlAsync(decimal minSalary, DateTime minDate);
}