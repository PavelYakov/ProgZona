using Microsoft.EntityFrameworkCore;

namespace Auth.Data;

public class UserContext: DbContext
{
    public UserContext(DbContextOptions< UserContext> options) : base(options)
    {
    }

    // DbSet и другие сущности для второй базы данных
    public virtual DbSet<UserInfoEntity> UserInfos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
       
    }
}