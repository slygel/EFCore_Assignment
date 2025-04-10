using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    
    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Employees>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employees> GetByIdAsync(Guid id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task AddAsync(Employees employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employees employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await GetByIdAsync(id);
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Employees>> GetAllWithDepartmentAsync()
    {
        return await _context.Employees
            .Include(e => e.Department)
            .ToListAsync();
    }

    public async Task<IEnumerable<Employees>> GetAllWithProjectsAsync()
    {
        return await _context.Employees
            .Include(e => e.ProjectEmployees)
            .ThenInclude(pe => pe.Projects)
            .ToListAsync();
    }

    public async Task<IEnumerable<Employees>> GetEmployeesBySalaryAndDateRawSqlAsync(decimal minSalary, DateTime minDate)
    {
        return await _context.Employees
            .FromSqlRaw(@"
                    SELECT e.*
                    FROM Employees e
                    INNER JOIN Salaries s ON e.Id = s.EmployeeId
                    WHERE s.Salary > {0} AND e.JoinedDate >= {1}",
                minSalary, minDate)
            .Include(e => e.Salary)
            .ToListAsync();
    }
}