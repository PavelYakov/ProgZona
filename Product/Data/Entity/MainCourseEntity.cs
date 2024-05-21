using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Data.Entity;
// Это самый главный курс
public class MainCourseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int DifficultLevel { get; set; }
    
    public int PurchaseCount { get; set; } // количество купивших
    public virtual List<CourseEntity> Courses { get; set; }
}
public class MainCourseEntityConfiguration : IEntityTypeConfiguration<MainCourseEntity>
{
    public void Configure(EntityTypeBuilder<MainCourseEntity> builder)
    {
        builder.ToTable("MainCourse");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        
        /*builder.HasMany(x => x.Courses)
            .WithOne()
            .IsRequired();*/
        
        builder.HasMany(x => x.Courses)
            .WithOne(c => c.MainCourse)
            .HasForeignKey(c => c.MainCourseId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
    
}