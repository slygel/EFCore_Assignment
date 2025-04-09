using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Departments>
{
    public void Configure(EntityTypeBuilder<Departments> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).HasMaxLength(100).IsRequired();
        
        builder.HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasData(
            new Departments { Id = Guid.NewGuid(), Name = "Software Development" },
            new Departments { Id = Guid.NewGuid(), Name = "Finance" },
            new Departments { Id = Guid.NewGuid(), Name = "Accountant" },
            new Departments { Id = Guid.NewGuid(), Name = "HR" }
        );
    }
}