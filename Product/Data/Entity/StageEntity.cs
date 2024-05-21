using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Models.Courses;

namespace Product.Data.Entity;

public class StageEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; } 
    public int StagePoint { get; set; } // показывает количество очков, необходимых для открытия этапа
    
    public int PurchaseCount { get; set; } // количество купивших
    
    public int CourseId { get; set; } // Внешний ключ для связи с курсом
    public CourseEntity Course { get; set; } // Навигационное свойство курса
    
    public virtual List<TaskLessonEntity> Tasks { get; set; } // связь с задачами
    public virtual List<TestLessonEntity> Tests { get; set; } // связь с тестами
}

public class StageEntityConfiguration: IEntityTypeConfiguration<StageEntity>
{
    public void Configure(EntityTypeBuilder<StageEntity> builder)
    {
        builder.ToTable("Stage");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.StagePoint).IsRequired();
        
        // Связь с предыдущим этапом (если есть)
       /* builder.HasOne(x => x.PreviousStage)
            .WithMany()
            .HasForeignKey(x => x.PreviousStageId)
            .IsRequired(false); // Разрешить NULL значения во внешнем ключе
            //.OnDelete(DeleteBehavior.Restrict); // Установить ограничение Restrict*/

        // Связь с курсом
        builder.HasOne(x => x.Course)
            .WithMany(c => c.Stages)
            .HasForeignKey(x => x.CourseId)
            .IsRequired();

        // Связь с задачами
        builder.HasMany(x => x.Tasks)
            .WithOne(t => t.Stage)
            .HasForeignKey(t => t.StageId);

        // Связь с тестами
        builder.HasMany(x => x.Tests)
            .WithOne(t => t.Stage)
            .HasForeignKey(t => t.StageId);

        
    }
}