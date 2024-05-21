using Microsoft.AspNetCore.Mvc;
using Product.Contracts.MainCourse;
using Product.Contracts.Stage;

namespace Product.Controllers;

[ApiController]
[Route("api/stage")]
public class StageController: ControllerBase
{
    private readonly IStageReader _stageReader;

    public StageController(IStageReader stageReader)
    {
        _stageReader = stageReader;
    }
    
    [HttpGet]
    //[Authorize]
    //[Log(LogLevel.Information, "Пользователь запросил список всех лекций")]
    public async Task<IActionResult> GetStage()
    {
        var stages = await _stageReader.GetStages();
        
        if (stages == null)
        {
            return NotFound("Список главных курсов пуст.");
        }
        
        return Ok(stages);
    }
    [HttpGet]
    [Route("get-stages-by-id")]
    //[Authorize]
    public async Task<IActionResult> GetStageById(int stageId)
    {
        // Получение списка главных лекиц
        var stages =  await _stageReader.GetStageById(stageId);

        // Проверка наличия курсов
        if (stages == null)
        {
            return NotFound("Список главных курсов пуст.");
        }

        // Возврат списка главных курсов
        return Ok(stages);
    }
}