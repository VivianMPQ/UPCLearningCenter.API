namespace UPCLearningCenter.API.Learning.Domain.Models;

public class Tutorial
{
    public long id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    //relacione 
    public long CategoryId { get; set; }
    public Category Category { get; set; }
}