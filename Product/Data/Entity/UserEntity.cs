using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Models.Achievements;

namespace Product.Data.Entity;

public class UserEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Point { get; set; }
    public int Level { get; set; }
    
   // public virtual List<CourseProgress> Progress { get; set; } // связь с моделью прогресса на курсе
    public virtual List<UserAchievementEntity> UserAchievements { get; set; }
}
public class UserEntityConfiguration: IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("UserProduct");
        
        builder.HasKey(x => x.Id);
        
       //builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired();
        
        builder
            .HasMany(x => x.UserAchievements)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}