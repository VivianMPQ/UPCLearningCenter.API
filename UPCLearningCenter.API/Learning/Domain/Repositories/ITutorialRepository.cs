using UPCLearningCenter.API.Learning.Domain.Models;

namespace UPCLearningCenter.API.Learning.Domain.Repositories;

public interface ITutorialRepository
{
    Task<IEnumerable<Tutorial>> ListAsync();
    Task AddAsync(Tutorial tutorial);
    Task<Tutorial> FinByIdAsync(long tutorialId);
    Task<Tutorial> FindByName(string name);
    Task<IEnumerable<Tutorial>> FindByCategoryIdAsync(long categoryId);
    void Update(Tutorial tutorial);
    void Remove(Tutorial tutorial);
}