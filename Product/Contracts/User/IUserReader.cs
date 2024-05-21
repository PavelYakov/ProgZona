namespace Product.Contracts.User;
using Product.Models.Users;
public interface IUserReader
{
    Task<User> GetUserById(int userId);
}