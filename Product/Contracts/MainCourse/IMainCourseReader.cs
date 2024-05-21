namespace Product.Contracts.MainCourse;
using Product.Models.Courses;

public interface IMainCourseReader
{
    //IEnumerable<Models.Courses.MainCourse> GetMainCourses();
    Task<IEnumerable<MainCourse>> GetMainCourses();
    Task<MainCourse> GetMainCourseById(int courseId);
}