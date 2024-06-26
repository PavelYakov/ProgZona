using Auth.JwtAuthManager.Models;

namespace Auth.Contracts;

public interface IUserManager
{
    Task RegisterAsync(string username, string password, string email);
    Task<string> LoginAsync(string username, string password);
    Task DeletedAsync(int id);
    Task<AuthenticationRequest> GetUser(int userId);
}