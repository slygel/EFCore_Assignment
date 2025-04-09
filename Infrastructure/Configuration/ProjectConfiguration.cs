using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ProjectConfiguration : IEntityTypeConfiguration<Projects>
{
    public void Configure(EntityTypeBuilder<Projects> builder)
    {
        builder.ToTable("Projects");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).HasMaxLength(100).IsRequired();
    }
}