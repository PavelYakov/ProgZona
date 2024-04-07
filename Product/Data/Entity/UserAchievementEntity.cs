using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Data.Entity;

public class UserAchievementEntity
{
    public int UserId { get; set; }
    public int AchievementId { get; set; }
    
    public virtual UserEntity User { get; set; }
    public virtual AchievementEntity Achievement { get; set; }
}

public class UserAchievementEntityConfiguration: IEntityTypeConfiguration<UserAchievementEntity>
{
    public void Configure(EntityTypeBuilder<UserAchievementEntity> builder)
    {
        builder.ToTable("UserAchievement");

        builder.HasKey(x => new { x.UserId, x.AchievementId });
    }
}