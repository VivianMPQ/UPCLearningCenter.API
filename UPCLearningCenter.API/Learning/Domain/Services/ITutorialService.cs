using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Services.Comunication;

namespace UPCLearningCenter.API.Learning.Domain.Services;

public interface ITutorialService
{
    Task<IEnumerable<Tutorial>> ListAsync();
    Task<IEnumerable<Tutorial>> ListByCategoryIdAsync(long categoryId);
    Task<TutorialResponse> SaveAsync(Tutorial tutorial);
    Task<TutorialResponse> UpdateAsync(long tutorialId, Tutorial tutorial);
    Task<TutorialResponse> DeleteAsync(long tutorialId);
}