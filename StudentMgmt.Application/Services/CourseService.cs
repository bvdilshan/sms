using StudentMgmt.Core.Entities;
using StudentMgmt.Core.Interfaces;

namespace StudentMgmt.Application.Services;

public class CourseService
{
    private readonly ICourseRepository _repository;

    public CourseService(ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Course>> GetAllCourses() => await _repository.GetAllAsync();
    
    public async Task<Course?> GetCourseById(string id) => await _repository.GetByIdAsync(id);

    public async Task AddCourse(Course course) => await _repository.CreateAsync(course);

    public async Task UpdateCourse(string id, Course course) => await _repository.UpdateAsync(id, course);

    public async Task RemoveCourse(string id) => await _repository.DeleteAsync(id);
}