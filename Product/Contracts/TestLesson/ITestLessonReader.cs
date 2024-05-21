namespace Product.Contracts.TestLesson;
using Product.Models.Tests;
public interface ITestLessonReader
{
    Task<IEnumerable<TestLesson>> GetTestLessons();
    Task<TestLesson> GetTestLessonById(int testLessonId);
}