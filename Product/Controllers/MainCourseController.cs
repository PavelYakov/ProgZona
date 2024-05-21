using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Contracts.MainCourse;
using Product.Models;
using Product.Models.Courses;

namespace Product.Controllers;

[ApiController]
[Route("api/mainCourse")]
public class MainCourseController: ControllerBase
{
    private readonly IMainCourseReader _mainCourseReader;

    public MainCourseController(IMainCourseReader mainCourseReader)
    {
        _mainCourseReader = mainCourseReader;
    }
    
    [HttpGet]
    //[Authorize]
    //[Log(LogLevel.Information, "Пользователь запросил список всех курсов")]
    public async Task<IActionResult> GetMainCourse()
    {
        var mainCourses = await _mainCourseReader.GetMainCourses();
        
        if (mainCourses == null)
        {
            return NotFound("Список главных курсов пуст.");
        }
        
        return Ok(mainCourses);
    }
    [HttpGet]
    [Route("get-main-course")]
    //[Authorize]
    public async Task<IActionResult> GetMainCourse(int courseId)
    {
        // Получение списка главных курсов из репозитория
        var mainCourses =  await _mainCourseReader.GetMainCourseById(courseId);

        // Проверка наличия курсов
        if (mainCourses == null)
        {
            return NotFound("Список главных курсов пуст.");
        }

        // Возврат списка главных курсов
        return Ok(mainCourses);
    }
    
}