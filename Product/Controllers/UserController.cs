using Microsoft.AspNetCore.Mvc;
using Product.Contracts.User;
using Product.Models.Users;

namespace Product.Controllers;

[ApiController]
[Route("api/user")]
public class UserController: ControllerBase
{
    private readonly IUserReader _userReader;
    public UserController(IUserReader userReader)
    {
        _userReader = userReader;
    }

    [HttpGet]
    [Route("get")]
    //[Authorize]
    public  async Task<ActionResult> GetUserById(int userId)
    {
        // Получение списка главных курсов из репозитория
        var user =  await _userReader.GetUserById(userId);

        // Проверка наличия курсов
        if (user == null)
        {
            return NotFound("Список пользователей пуст.");
        }

        // Возврат списка главных курсов
        return Ok(user);
    }
    
}