using JwtAuthManager;
using JwtAuthManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers;
[ApiController]
[Route("api/auth")]
public class AccountController: ControllerBase
{
    private readonly JwtTokenHandler _jwtTokenHandler;

    public AccountController(JwtTokenHandler jwtTokenHandler)
    {
        _jwtTokenHandler = jwtTokenHandler;
    }

    [HttpPost]
    public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
    {
        var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
        if (authenticationResponse == null) return Unauthorized();
        return authenticationResponse;


    }
}