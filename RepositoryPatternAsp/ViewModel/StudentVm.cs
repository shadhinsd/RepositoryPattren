using AutoMapper;
using RepositoryPatternAsp.Models;

namespace RepositoryPatternAsp.ViewModel;
[AutoMap(typeof(Student),ReverseMap =true)]
public class StudentVm
{
    public long Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public string Email { get; set; }=string.Empty;
    public string Phone { get; set; }=string.Empty;
}
