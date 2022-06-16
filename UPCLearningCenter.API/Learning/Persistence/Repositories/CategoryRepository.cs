using Microsoft.EntityFrameworkCore;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Repositories;
using UPCLearningCenter.API.Learning.Persistence.Contexts;

namespace UPCLearningCenter.API.Learning.Persistence.Repositories;
public class CategoryRepository: BaseRepository, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
        await context.Categories.AddAsync(category);
    }

    public async Task<Category?> FinByIdAsync(long id)
    {
        return await context.Categories.FindAsync(id);
    }
    
    public void Update(Category category)
    {
        context.Categories.Update(category);
    }

    public void Remove(Category category)
    {
        context.Categories.Remove(category);
    }
}