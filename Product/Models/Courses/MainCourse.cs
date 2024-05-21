using Product.Data.Entity;

namespace Product.Models.Courses;

public class MainCourse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int DifficultLevel { get; set; }
    
    public int PurchaseCount { get; set; } // количество купивших
    //public virtual List<CourseEntity> Courses { get; set; }
}