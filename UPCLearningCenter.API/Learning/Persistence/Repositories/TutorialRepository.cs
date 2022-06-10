using Microsoft.EntityFrameworkCore;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Repositories;
using UPCLearningCenter.API.Learning.Persistence.Contexts;

namespace UPCLearningCenter.API.Learning.Persistence.Repositories;

public class TutorialRepository: BaseRepository, ITutorialRepository
{
    public TutorialRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Tutorial>> ListAsync()
    {
        return await context.Tutorials
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task AddAsync(Tutorial tutorial)
    {
        await context.Tutorials.AddAsync(tutorial);
    }

    public async Task<Tutorial?> FinByIdAsync(long tutorialId)
    {
        return await context.Tutorials
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.id == tutorialId)!;
        
    }

    public async Task<Tutorial?> FindByTitleAsync(string title)
    {
        return await context.Tutorials
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<IEnumerable<Tutorial>> FindByCategoryIdAsync(long categoryId)
    {
        return await context.Tutorials
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .ToListAsync();
    }

    public void Update(Tutorial tutorial)
    {
        context.Tutorials.Update(tutorial);
    }

    public void Remove(Tutorial tutorial)
    {
        context.Tutorials.Remove(tutorial);
    }
}