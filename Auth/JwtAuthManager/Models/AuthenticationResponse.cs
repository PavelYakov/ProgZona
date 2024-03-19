namespace Auth.JwtAuthManager.Models;

public class AuthenticationResponse
{
    public string UserName { get; set; }
    public string JwtToken { get; set; }
    public int ExpiresIn { get; set; }
}