using Product.Contracts.TestLesson;
using Product.Data.Context;
using Product.Models.Tests;

namespace Product.Services.TestLessonService;

internal sealed class TestLessonReader:ITestLessonReader
{
    private readonly ProductContext _ctx;
    
    public TestLessonReader(ProductContext ctx)
    {
        _ctx = ctx;
    }

    public Task<IEnumerable<TestLesson>> GetTestLessons()
    {
        throw new NotImplementedException();
    }

    public Task<TestLesson> GetTestLessonById(int testLessonId)
    {
        throw new NotImplementedException();
    }
}