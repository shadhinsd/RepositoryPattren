using AutoMapper;
using RepositoryPatternAsp.DatabaseContext;
using RepositoryPatternAsp.Models;
using RepositoryPatternAsp.Service;
using RepositoryPatternAsp.ViewModel;

namespace RepositoryPatternAsp.RepositoryService;

public class StudentRepository : RepositoryService<Student, StudentVm>, IStudentRepository
{
    public StudentRepository(IMapper mapper, StudentDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
