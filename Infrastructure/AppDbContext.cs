using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Departments> Departments { get; set; }
    public DbSet<Projects> Projects { get; set; }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
    public DbSet<Salaries> Salaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Auto discovers and applies all implementations of IEntityTypeConfiguration<T>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}