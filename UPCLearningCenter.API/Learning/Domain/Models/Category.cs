namespace UPCLearningCenter.API.Learning.Domain.Models;

public class Category
{
    public int id { get; set; }
    public string Name { get; set; }

    //relaciones
    public IList<Tutorial> Tutorials { get; set; } = new List<Tutorial>();
}