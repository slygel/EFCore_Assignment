using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;
    
    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Projects>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Projects> GetByIdAsync(Guid id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task AddAsync(Projects projects)
    {
        await _context.Projects.AddAsync(projects);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Projects projects)
    {
        _context.Projects.Update(projects);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var project = await GetByIdAsync(id);
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
    }
}