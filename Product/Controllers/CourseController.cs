using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Product.Contracts.Course;
using Product.Models.Courses;

namespace Product.Controllers;

[ApiController]
[Route("api/course")]
public class CourseController: ControllerBase
{
    private readonly ICourseReader _courseReader;
    
    public CourseController(ICourseReader courseReader)
    {
        _courseReader = courseReader;
    }

    [HttpGet]
    
    public async Task<IEnumerable<Course>> GetCourse()
    {
        return await _courseReader.GetCourses();

       
    }
    
    [HttpGet]
    [Route("get-by-id")]
    public async Task<IActionResult> GetCourseById(int courseId)
    {
        var course= await _courseReader.GetCoursesById(courseId);

        return Ok(course);
    }
}