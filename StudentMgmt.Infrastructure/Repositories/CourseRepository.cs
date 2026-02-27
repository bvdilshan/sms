using MongoDB.Driver;
using StudentMgmt.Core.Entities;
using StudentMgmt.Core.Interfaces;
using StudentMgmt.Infrastructure.Data;

namespace StudentMgmt.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly MongoDbContext _context;

    public CourseRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllAsync() =>
        await _context.Courses.Find(_ => true).ToListAsync();

    public async Task<Course?> GetByIdAsync(string id) =>
        await _context.Courses.Find(c => c.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Course course) =>
        await _context.Courses.InsertOneAsync(course);

    public async Task UpdateAsync(string id, Course course) =>
        await _context.Courses.ReplaceOneAsync(c => c.Id == id, course);

    public async Task DeleteAsync(string id) =>
        await _context.Courses.DeleteOneAsync(c => c.Id == id);
}