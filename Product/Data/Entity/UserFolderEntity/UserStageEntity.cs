using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Data.Entity.UserFolderEntity;

public class UserStageEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int StageId { get; set; }
    public bool IsBought { get; set; }
}
public class UserStagetEntityConfiguration: IEntityTypeConfiguration<UserStageEntity>
{
    public void Configure(EntityTypeBuilder<UserStageEntity> builder)
    {
        builder.ToTable("UserStage");

        builder.HasKey(x => new { x.UserId, x.StageId });
    }
}