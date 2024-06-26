namespace Product.Models.Achievements;

//Содержит информацию о достижениях пользователя, полученных при выполнении определенных заданий, тестов или завершении курсов.
//Включает в себя название достижения, описание и условия для его получения.
public class Achievement
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}