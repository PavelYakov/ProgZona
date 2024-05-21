using Microsoft.EntityFrameworkCore;
using Product.Contracts.Course;
using Product.Data.Context;
using Product.Models.Courses;

namespace Product.Services.CourseService;

internal sealed class CourseReader : ICourseReader
{
    private readonly ProductContext _ctx;

    public CourseReader(ProductContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<IEnumerable<Course>> GetCourses()
    {
        var course = await _ctx.Courses.ToListAsync();
        
        var courses = course.Select(mc => new Course
        {
            Id = mc.Id,
            Name = mc.Name,
            Description = mc.Description
            
        }).ToList();

        return courses;
    }

    public  async Task<Course> GetCoursesById(int courseId)
    {
        var cour = await _ctx.Courses.FirstOrDefaultAsync(p => p.Id == courseId);
        
        var course =  new Course
        {
            Id = cour.Id,
            Name = cour.Name,
            Description = cour.Description
            
        }; 
        return course;
    }
}