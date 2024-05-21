using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Data.Entity.UserFolderEntity;

public class UserCourseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CourseId { get; set; }
    public bool IsBought { get; set; }
}
public class UserCourseEntityConfiguration: IEntityTypeConfiguration<UserCourseEntity>
{
    public void Configure(EntityTypeBuilder<UserCourseEntity> builder)
    {
        builder.ToTable("UserCourse");

        builder.HasKey(x => new { x.UserId, x.CourseId });
    }
}