namespace Product.Contracts.TaskLesson;
using Product.Models.Tasks;
public interface ITaskLessonReader
{
    Task<IEnumerable<TaskLesson>> GetTaskLessons();
    Task<TaskLesson> GetTaskLessonById(int taskLessonId);
}