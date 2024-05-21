using Microsoft.EntityFrameworkCore;
using Product.Contracts.MainCourse;
using Product.Data.Context;
using Product.Models.Courses;

namespace Product.Services.MainCourseService;

internal sealed class MainCourseReader: IMainCourseReader
{
    
    private readonly ProductContext _ctx;
    
    public MainCourseReader(ProductContext ctx)
    {
        _ctx = ctx;
    }
    public async Task<IEnumerable<MainCourse>> GetMainCourses()
    {
        var mainCourseEntities = await _ctx.MainCourses.ToListAsync();
        var mainCourses = mainCourseEntities.Select(mc => new MainCourse
        {
            Id = mc.Id,
            Name = mc.Name,
            Description = mc.Description,
            DifficultLevel = mc.DifficultLevel,
            PurchaseCount = mc.PurchaseCount
            
        }).ToList();
        
        return mainCourses;
    }

    public async Task<MainCourse> GetMainCourseById(int courseId)
    {
        var mainCourseEntity = await _ctx.MainCourses.FirstOrDefaultAsync(mc => mc.Id == courseId);
        if (mainCourseEntity == null)
        {
            // Вернуть null или бросить исключение, если курс с указанным идентификатором не найден
            return null;
        }

        
        var mainCourse = new MainCourse
        {
            Id = mainCourseEntity.Id,
            Name = mainCourseEntity.Name,
            Description = mainCourseEntity.Description,
            DifficultLevel = mainCourseEntity.DifficultLevel,
            PurchaseCount = mainCourseEntity.PurchaseCount
            
        };

        return mainCourse;
    }
}