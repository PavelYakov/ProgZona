using Auth.Data;
using Microsoft.EntityFrameworkCore;
using Product.Data.Entity;
using Product.Models.Achievements;
using UserEntity = Auth.Data.UserEntity;
using UserEntityConfiguration = Product.Data.Entity.UserEntityConfiguration;

namespace Product.Data.Context;

public class ProductContext: DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public virtual DbSet<AchievementEntity> Achievements { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }
    public virtual DbSet<CourseEntity> Courses { get; set; }
    public virtual DbSet<StageEntity> Stages { get; set; }
    public virtual DbSet<TaskLessonEntity> TasksLesson { get; set; }
    public virtual DbSet<TestLessonEntity> TestsLesson  { get; set; }
    
    public DbSet<UserAchievementEntity> UserAchievements { get; set; }
    
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=Yakovbook\\SQLEXPRESS;Database=ProductProgZona;User Id=sa;Password=sa;TrustServerCertificate=True;");
    }*/
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AchievementEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration()); 
        modelBuilder.ApplyConfiguration(new CourseEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StageEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TaskLessonEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TestLessonEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserAchievementEntityConfiguration());
        modelBuilder.Ignore<UserRoleEntity>();
        modelBuilder.Ignore<UserEntity>();
        modelBuilder.Ignore<AuthEntity>();
        modelBuilder.Ignore<RoleEntity>();
    }
}