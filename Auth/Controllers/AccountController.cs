using Auth.Contracts;
using Auth.JwtAuthManager;
using Auth.JwtAuthManager.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers;
[ApiController]
[Route("api/auth")]
public class AccountController: ControllerBase
{
    private readonly JwtTokenHandler _jwtTokenHandler;
    private readonly IUserManager _userManager;

    public AccountController(JwtTokenHandler jwtTokenHandler,UserManager userManager)
    {
        _jwtTokenHandler = jwtTokenHandler;
        _userManager = userManager;
    }

    [HttpPost]
    public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
    {
        var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
        if (authenticationResponse == null) return Unauthorized();
        return authenticationResponse;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthenticationRequest request)
    {
        /*await _userManager.RegisterAsync(request.UserName, request.Password);
        return Ok();*/
        
        // Проверяем валидность модели
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Регистрируем нового пользователя
        await _userManager.RegisterAsync(request.UserName, request.Password, request.Email);
        return Ok("Пользователь успешно зарегистрирован.");
            
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await _userManager.LoginAsync(request.UserName, request.Password);
        return Ok(new { Token = token });
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        await _userManager.DeletedAsync(id);
        return Ok("Пользователь успешно зарегистрирован.");
    }
}