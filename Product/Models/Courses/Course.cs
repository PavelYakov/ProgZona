using Product.Models.Stages;

namespace Product.Models.Courses;

//Курсы (Courses):
//Описывает каждый доступный курс, включая его название, описание, уровень сложности и другие характеристики.
//Может содержать информацию о доступных этапах курса и связанных заданиях или тестах.
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LevelDifficult { get; set; }
    public List<Stage> Stages { get; set; }

}