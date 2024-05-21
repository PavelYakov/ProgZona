namespace Product.Contracts.Course;
using Product.Models.Courses;

public interface ICourseReader
{
    Task<IEnumerable<Course>> GetCourses();
    Task<Course> GetCoursesById(int courseId);
    
}