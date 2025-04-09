using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
        builder.Property(e => e.JoinedDate).IsRequired();
        
        builder.HasOne(e => e.Salary)
            .WithOne(s => s.Employees)
            .HasForeignKey<Salaries>(e => e.EmployeeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}