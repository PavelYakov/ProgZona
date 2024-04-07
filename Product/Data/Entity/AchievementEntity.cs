using Auth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Data.Entity;

public class AchievementEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    // public int UserId { get; set; } // Внешний ключ для связи с юзером
    //public UserEntity User { get; set; } // Навигационное свойство курса
    public virtual List<UserAchievementEntity> UserAchievements { get; set; }
}
public class AchievementEntityConfiguration: IEntityTypeConfiguration<AchievementEntity>
{
    public void Configure(EntityTypeBuilder<AchievementEntity> builder)
    {
        builder.ToTable("Achievement");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        
        builder
            .HasMany(x => x.UserAchievements)
            .WithOne(x => x.Achievement)
            .HasForeignKey(x => x.AchievementId)
            .OnDelete(DeleteBehavior.Cascade);

        
    }
}