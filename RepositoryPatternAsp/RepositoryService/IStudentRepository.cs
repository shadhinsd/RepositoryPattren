using RepositoryPatternAsp.Models;
using RepositoryPatternAsp.Service;
using RepositoryPatternAsp.ViewModel;

namespace RepositoryPatternAsp.RepositoryService;

public interface IStudentRepository:IRepositoryService<Student,StudentVm>
{
}
