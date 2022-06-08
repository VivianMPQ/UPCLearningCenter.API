using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Services.Comunication;

namespace UPCLearningCenter.API.Learning.Domain.Services;

public class ICategoryService
{
    Task<IEnumerable<Category>> ListAsync();
    Task<CategoryResponse> SaveAsync(Category category);
    Task<CategoryResponse> UpdateAsync(long id, Category category);
    Task<CategoryResponse> DeleteAsync(long id);
}