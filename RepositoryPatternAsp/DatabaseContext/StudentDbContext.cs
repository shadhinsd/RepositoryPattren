using Microsoft.EntityFrameworkCore;
using RepositoryPatternAsp.ViewModel;

namespace RepositoryPatternAsp.DatabaseContext;

public class StudentDbContext(DbContextOptions<StudentDbContext> dbContext) : DbContext(dbContext)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);
    }

public DbSet<RepositoryPatternAsp.ViewModel.StudentVm> StudentVm { get; set; } = default!;
}
