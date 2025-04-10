using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProjectEmployeeRepository : IProjectEmployeeRepository
{
    private readonly AppDbContext _context;
    
    public ProjectEmployeeRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProjectEmployee>> GetAllAsync()
    {
        return await _context.ProjectEmployees.ToListAsync();
    }

    public async Task<ProjectEmployee> GetByIdAsync(Guid projectId, Guid employeeId)
    {
        return await _context.ProjectEmployees
            .FirstOrDefaultAsync(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId);
    }

    public async Task AddAsync(ProjectEmployee projectEmployee)
    {
        await _context.ProjectEmployees.AddAsync(projectEmployee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProjectEmployee projectEmployee)
    {
        _context.ProjectEmployees.Update(projectEmployee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid projectId, Guid employeeId)
    {
        var projectEmployee = await GetByIdAsync(projectId, employeeId);
        if (projectEmployee != null)
        {
            _context.ProjectEmployees.Remove(projectEmployee);
            await _context.SaveChangesAsync();
        }
    }
}