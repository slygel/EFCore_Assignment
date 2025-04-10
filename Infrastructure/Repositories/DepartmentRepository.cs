using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;
    
    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Departments>> GetAllAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Departments> GetByIdAsync(Guid id)
    {
        return await _context.Departments.FindAsync(id);
    }

    public async Task AddAsync(Departments department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Departments department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var department = await GetByIdAsync(id);
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
    }
}