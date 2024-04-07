namespace Product.Models.Tasks;

//Описывает задания, которые пользователь должен выполнить в процессе обучения.
//Может включать описание задания, требования к выполнению и критерии оценки.
public class TaskLesson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Point { get; set; } // количество баллов, выдаваемых за выполнение задачи
}