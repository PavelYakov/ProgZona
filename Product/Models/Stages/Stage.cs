using Product.Models.Courses;

namespace Product.Models.Stages;
//Этапы (Stages):
//Представляет каждый этап курса, который пользователь должен пройти для завершения всего курса.
//  Включает в себя информацию о теме этапа, описании, материалах и тестах или заданиях.

public class Stage
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int StagePoint { get; set; } // показывает количество очков, необходимых для открытия этапа
    public string Text { get; set; }

    public int CourseId { get; set; } // Внешний ключ для связи с курсом
    public Course Course { get; set; } // Навигационное свойство курса
}