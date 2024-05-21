using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Models.Stages;

namespace Product.Data.Entity;

public class CourseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    //public int LevelDifficult { get; set; } // пока сомнительно
    public int PurchaseCount { get; set; } // количество купивших
    public virtual List<StageEntity> Stages { get; set; } 
    
    public int MainCourseId { get; set; } // Внешний ключ для связи с  главным курсом
    public virtual MainCourseEntity MainCourse { get; set; } // Навигационное свойство главного курса
}
public class CourseEntityConfiguration: IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.ToTable("Course");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder
            .HasMany(x => x.Stages)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Связь с курсом
        builder.HasOne(x => x.MainCourse)
            .WithMany(c => c.Courses)
            .HasForeignKey(x => x.MainCourseId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}