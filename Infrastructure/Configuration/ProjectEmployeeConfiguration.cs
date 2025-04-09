using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
{
    public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
    {
        builder.ToTable("ProjectEmployee");
        builder.HasKey(pe => new { pe.ProjectId, pe.EmployeeId });
        builder.Property(pe => pe.Enable)
            .IsRequired();
        
        builder
            .HasOne(pe => pe.Projects)
            .WithMany(p => p.ProjectEmployees)
            .HasForeignKey(pe => pe.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(pe => pe.Employee)
            .WithMany(e => e.ProjectEmployees)
            .HasForeignKey(pe => pe.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}