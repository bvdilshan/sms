using StudentMgmt.Core.Entities;

namespace StudentMgmt.Core.Interfaces;

public interface ICourseRepository
{
    // Get all courses 
    Task<IEnumerable<Course>> GetAllAsync();

    // Find a specific course 
    Task<Course?> GetByIdAsync(string id);

    // Save a new course 
    Task CreateAsync(Course course);

    // Update an existing course's details
    Task UpdateAsync(string id, Course course);

    // Remove a course 
    Task DeleteAsync(string id);
}