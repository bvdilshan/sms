using Microsoft.AspNetCore.Mvc;
using StudentMgmt.Application.Services;
using StudentMgmt.Core.Entities;

namespace StudentMgmt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly CourseService _courseService;

    public CoursesController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> Get() => Ok(await _courseService.GetAllCourses());

    [HttpPost]
    public async Task<IActionResult> Post(Course course)
    {
        await _courseService.AddCourse(course);
        return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _courseService.RemoveCourse(id);
        return NoContent();
    }
}