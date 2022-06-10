namespace UPCLearningCenter.API.Learning.Resources;

public class TutorialResource
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public CategoryResource Category { get; set; }
}