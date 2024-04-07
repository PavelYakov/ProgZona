using System.Security.Cryptography;
using System.Text;
using Auth.Contracts;
using Auth.Data;
using Auth.JwtAuthManager;
using Microsoft.EntityFrameworkCore;
//using JwtAuthManager;
using AuthenticationRequest = Auth.JwtAuthManager.Models.AuthenticationRequest;

namespace Auth.Services;

public class UserManager : IUserManager
{
    private readonly AuthContext _ctx;
    private readonly UserContext _userctx;
    private readonly JwtTokenHandler _jwtTokenHandler;

    public UserManager(AuthContext ctx, JwtTokenHandler jwtTokenHandler,  UserContext userctx)
    {
        _ctx = ctx;
        _jwtTokenHandler = jwtTokenHandler;
        _userctx = userctx;
    }

    public async Task RegisterAsync(string username, string password, string email)
    {
        // Проверяем, существует ли пользователь с таким же именем
        var existingUser = await _ctx.Users.FirstOrDefaultAsync(u => u.Name == username);
        if (existingUser != null)
            throw new InvalidOperationException("Пользователь с таким именем уже существует");


        // Создаем нового пользователя
        var newUser = new UserEntity
        {
            Name = username,
            PasswordHash = HashPassword(password),
            Email = email
        };
        var newUserInfo = new UserInfoEntity()
        {
            Name = username,
            Level = 0,
            Point = 10,
            Email = email
        };
        
        _ctx.Users.Add(newUser);
        _userctx.UserInfos.Add(newUserInfo);
        
        await _ctx.SaveChangesAsync();
        await _userctx.SaveChangesAsync();
        
        int userId = newUser.Id;
        
        _ctx.UsersRoles.Add(new UserRoleEntity
        {
            UserId = userId,
            RoleId = 1
        });
        await _ctx.SaveChangesAsync();
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        // Поиск пользователя по имени
        var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Name == username);
        if (user == null) return "Неверное имя пользователя или пароль.";

        // Проверяем правильность пароля
        var passwordCorrect = VerifyPassword(user, password);
        if (!passwordCorrect) return "Неверное имя пользователя или пароль.";

        // Генерация токена для успешной аутентификации
        var authenticationRequest = new AuthenticationRequest
        {
            // Здесь передайте необходимые данные для генерации токена
            UserName = username,
            Password = password
        };

        var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
        if (authenticationResponse == null) return "Ошибка генерации токена.";

        // Преобразование секунд в TimeSpan
        var expiresInTimeSpan = TimeSpan.FromSeconds(authenticationResponse.ExpiresIn);

        // Вычисление даты истечения срока действия
        var expireDate = DateTime.UtcNow.Add(expiresInTimeSpan);

        _ctx.Tokens.Add(new AuthEntity
        {
            Token = authenticationResponse.JwtToken,
            IssueDate = DateTime.UtcNow,
            ExpireDate = expireDate,
            UserId = user.Id
        });
        await _ctx.SaveChangesAsync();

        return authenticationResponse.JwtToken;
    }
    public async Task DeletedAsync(int id)
    {
        // Поиск пользователя по имени
        var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            // Если пользователь не найден, можно выбросить исключение или просто завершить метод
            return; // или throw new Exception("User not found");
        }

        // Удаляем пользователя из контекста базы данных
        _ctx.Users.Remove(user);

        // Сохраняем изменения в базе данных
        await _ctx.SaveChangesAsync();
    }
    private bool VerifyPassword(UserEntity user, string password)
    {
        // Получаем хэш пароля из базы данных
        var hashedPasswordFromDatabase = user.PasswordHash;

        // Хэшируем введенный пароль
        var hashedPassword = HashPassword(password);

        // Сравниваем хэши
        return hashedPasswordFromDatabase == hashedPassword;
    }

    // Метод для хэширования пароля
    private string HashPassword(string password)
    {
        // Создаем объект для вычисления хэша
        using var sha256 = SHA256.Create();

        // Вычисляем хэш пароля
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

        // Преобразуем байты в строку HEX
        var builder = new StringBuilder();
        foreach (var b in hashedBytes) builder.Append(b.ToString("x2"));

        // Возвращаем захэшированный пароль в виде строки
        return builder.ToString();
    }
}