using UPCLearningCenter.API.Learning.Domain.Models;

namespace UPCLearningCenter.API.Learning.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> ListAsync();
    Task AddAsync(Category category);
    Task<Category> FinByIdAsync(long id);
    void Update(Category category);
    void Remove(Category category);

}