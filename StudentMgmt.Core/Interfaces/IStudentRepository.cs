using StudentMgmt.Core.Entities;

namespace StudentMgmt.Core.Interfaces;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(string id);
    Task CreateAsync(Student student);
    Task UpdateAsync(string id, Student student);
    Task DeleteAsync(string id);
}