using MongoDB.Driver;
using StudentMgmt.Core.Entities;
using StudentMgmt.Core.Interfaces;
using StudentMgmt.Infrastructure.Data;

namespace StudentMgmt.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly MongoDbContext _context;

    public StudentRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync() =>
        await _context.Students.Find(_ => true).ToListAsync();

    public async Task<Student?> GetByIdAsync(string id) =>
        await _context.Students.Find(s => s.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Student student) =>
        await _context.Students.InsertOneAsync(student);

    public async Task UpdateAsync(string id, Student student) =>
        await _context.Students.ReplaceOneAsync(s => s.Id == id, student);

    public async Task DeleteAsync(string id) =>
        await _context.Students.DeleteOneAsync(s => s.Id == id);
}