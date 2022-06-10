using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace UPCLearningCenter.API.Learning.Resources;

public class SaveTutorialResource
{
    //cada dato debe ser igual a lo estipulado en DbContext
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(120)]
    public string Description { get; set; }
    [Required]
    public long CategoryId { get; set; }
}