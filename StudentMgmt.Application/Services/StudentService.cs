using StudentMgmt.Core.Entities;
using StudentMgmt.Core.Interfaces;

namespace StudentMgmt.Application.Services;

public class StudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Student>> GetStudents() => await _repository.GetAllAsync();
    
    public async Task AddStudent(Student student) => await _repository.CreateAsync(student);
    public async Task<Student?> GetStudentById(string id) => await _repository.GetByIdAsync(id);

public async Task UpdateStudent(string id, Student student) 
{
    
    await _repository.UpdateAsync(id, student);
}

public async Task DeleteStudent(string id) => await _repository.DeleteAsync(id);
}