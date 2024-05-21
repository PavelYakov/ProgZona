using Product.Contracts.TaskLesson;
using Product.Data.Context;
using Product.Models.Tasks;

namespace Product.Services.TaskLessonService;

internal sealed class TaskLessonReader:ITaskLessonReader
{
    private readonly ProductContext _ctx;

    public TaskLessonReader(ProductContext ctx)
    {
        _ctx = ctx;
    }

    public Task<IEnumerable<TaskLesson>> GetTaskLessons()
    {
        throw new NotImplementedException();
    }

    public Task<TaskLesson> GetTaskLessonById(int taskLessonId)
    {
        throw new NotImplementedException();
    }
}