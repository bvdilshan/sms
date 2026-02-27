using Microsoft.AspNetCore.Mvc;
using StudentMgmt.Application.Services;
using StudentMgmt.Core.Entities;

namespace StudentMgmt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentsController(StudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> Get()
    {
        var students = await _studentService.GetStudents();
        return Ok(students);
    }

    // POST: api/students
    [HttpPost]
    public async Task<IActionResult> Post(Student student)
    {
        await _studentService.AddStudent(student);
        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }
    // GET: api/students/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetById(string id)
    {
        var student = await _studentService.GetStudentById(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    // PUT: api/students/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Student student)
    {
        var existingStudent = await _studentService.GetStudentById(id);
        if (existingStudent == null) return NotFound();

        student.Id = existingStudent.Id; 
        await _studentService.UpdateStudent(id, student);
        return NoContent();
    }

    // DELETE: api/students/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingStudent = await _studentService.GetStudentById(id);
        if (existingStudent == null) return NotFound();

        await _studentService.DeleteStudent(id);
        return NoContent();
    }
}