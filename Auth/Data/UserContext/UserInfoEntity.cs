using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data;

public class UserInfoEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Point { get; set; }
    public string Email { get; set; }
}
public class UserInfoConfiguration: IEntityTypeConfiguration<UserInfoEntity>
{
    public void Configure(EntityTypeBuilder<UserInfoEntity> builder)
    {
        builder.ToTable("UserProduct");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
    }
}