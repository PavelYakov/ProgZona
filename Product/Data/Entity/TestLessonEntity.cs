using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Data.Entity;

public class TestLessonEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public string TrueAnswer { get; set; }
    public int Point { get; set; } // количество баллов, выдаваемых за выполнение теста
    
    public int StageId { get; set; } // Внешний ключ для связи с курсом
    public StageEntity Stage { get; set; } // Навигационное свойство курса
}
public class TestLessonEntityConfiguration: IEntityTypeConfiguration<TestLessonEntity>
{
    public void Configure(EntityTypeBuilder<TestLessonEntity> builder)
    {
        builder.ToTable("TestLesson");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        
        // Связь с этапом
        builder.HasOne(x => x.Stage)
            .WithMany(s => s.Tests)
            .HasForeignKey(x => x.StageId)
            .IsRequired();

        
    }
}