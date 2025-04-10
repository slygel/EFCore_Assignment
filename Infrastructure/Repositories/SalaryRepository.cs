using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SalaryRepository : ISalaryRepository
{
    private readonly AppDbContext _context;
    
    public SalaryRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Salaries>> GetAllAsync()
    {
        return await _context.Salaries.ToListAsync();
    }

    public async Task<Salaries> GetByIdAsync(Guid id)
    {
        return await _context.Salaries.FindAsync(id);
    }

    public async Task AddAsync(Salaries salaries)
    {
        await _context.Salaries.AddAsync(salaries);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Salaries salaries)
    {
        _context.Salaries.Update(salaries);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var salary = await GetByIdAsync(id);
        _context.Salaries.Remove(salary);
        await _context.SaveChangesAsync();
    }
}