using System.IdentityModel.Tokens.Jwt;
using Product.Models.Users;

namespace Product.Services;

public class PersonInfo
{
    public User ParseJwtToken(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

        var userIdClaim = jsonToken?.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        int userId;
        if (int.TryParse(userIdClaim, out userId))
        {
            var userName = jsonToken?.Claims.FirstOrDefault(x => x.Type == "UserName")?.Value;

            return new User
            {
                Id = userId,
                Name = userName
            };
        }
        else
        {
            // В случае некорректного значения UserId возвращаем null или выбрасываем исключение
            throw new Exception("Некорректное значение UserId в JWT токене.");
        }
    }
}