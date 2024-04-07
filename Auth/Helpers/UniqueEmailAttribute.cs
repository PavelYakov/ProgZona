using System.ComponentModel.DataAnnotations;
using Auth.Data;

namespace Auth.Helpers;

public class UniqueEmailAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var email = value as string;

        if (email != null)
        {
            var dbContext = (AuthContext)validationContext.GetService(typeof(AuthContext));

            // Проверяем, существует ли пользователь с таким же Email
            var existingUser = dbContext.Users.FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                return new ValidationResult("Email уже используется.");
            }
        }

        return ValidationResult.Success;
    }
}