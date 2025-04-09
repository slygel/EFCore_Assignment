using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SalaryConfiguration : IEntityTypeConfiguration<Salaries>
{
    public void Configure(EntityTypeBuilder<Salaries> builder)
    {
        builder.ToTable("Salaries");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Salary)
            .IsRequired()
            .HasColumnType("decimal(18,3)");
        
    }
}