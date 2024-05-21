using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Data.Entity.UserFolderEntity;

public class UserMainCourseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MainCourseId { get; set; }
    public bool IsBought { get; set; }
}
public class UserMainCourseEntityConfiguration: IEntityTypeConfiguration<UserMainCourseEntity>
{
    public void Configure(EntityTypeBuilder<UserMainCourseEntity> builder)
    {
        builder.ToTable("UserMainCourse");

        builder.HasKey(x => new { x.UserId, x.MainCourseId });
    }
}