using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Data.Entity;

public class TaskLessonEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public string TrueAnswer { get; set; }
    public int Point { get; set; } // количество баллов, выдаваемых за выполнение задачи
    
    public int StageId { get; set; } // Внешний ключ для связи с этапом
    public StageEntity Stage { get; set; } // Навигационное свойство этапа
}

public class TaskLessonEntityConfiguration: IEntityTypeConfiguration<TaskLessonEntity>
{
    public void Configure(EntityTypeBuilder<TaskLessonEntity> builder)
    {
       builder.ToTable("TaskLesson");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.TrueAnswer).IsRequired();
        builder.Property(x => x.Point).IsRequired();

        // Связь с этапом
        builder.HasOne(x => x.Stage)
               .WithMany(s => s.Tasks)
               .HasForeignKey(x => x.StageId)
               .IsRequired();
        
    }
}