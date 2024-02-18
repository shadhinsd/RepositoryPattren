using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPatternAsp.Models;

namespace RepositoryPatternAsp.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable(nameof(Student));
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasMaxLength(50);
        builder.Property(t => t.Email).HasMaxLength(50);
        builder.Property(t => t.Phone).HasMaxLength(20);
    }
}
