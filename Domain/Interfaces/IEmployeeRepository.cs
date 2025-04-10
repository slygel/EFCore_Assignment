using Domain.Entities;

namespace Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employees>> GetAllAsync();
    Task<Employees> GetByIdAsync(Guid id);
    Task AddAsync(Employees employee);
    Task UpdateAsync(Employees employee);
    Task DeleteAsync(Guid id);
    
    Task<IEnumerable<Employees>> GetAllWithDepartmentAsync();
    Task<IEnumerable<Employees>> GetAllWithProjectsAsync();
    Task<IEnumerable<Employees>> GetEmployeesBySalaryAndDateRawSqlAsync(decimal minSalary, DateTime minDate);
}