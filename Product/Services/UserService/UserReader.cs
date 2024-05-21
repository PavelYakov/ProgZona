using Microsoft.EntityFrameworkCore;
using Product.Contracts.User;
using Product.Data.Context;
using Product.Models.Users;

namespace Product.Services.UserService;

public class UserReader:IUserReader
{
    private readonly ProductContext _ctx;
    
    public UserReader(ProductContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<User> GetUserById(int userId)
    {
        //var user = await _ctx.UsersProduct.FromSqlRaw("SELECT * FROM UserProduct WHERE Id = {0}", userId).FirstOrDefaultAsync();
        var user =  await _ctx.UsersProduct.FirstOrDefaultAsync(p => p.Id == userId);
        
        var users = new User()
        {
            Id = user.Id,
            Name = user.Name,
            Point = user.Point
        };
        
        return users;
    }
    
}