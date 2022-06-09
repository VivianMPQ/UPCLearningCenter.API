using UPCLearningCenter.API.Learning.Domain.Repositories;
using UPCLearningCenter.API.Learning.Persistence.Contexts;

namespace UPCLearningCenter.API.Learning.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;

    public UnitOfWork(AppDbContext context) {
        this.context = context;
    }

    //es CompleteAsync por el IUnitOfWork de learning-> domain-> repositories
    public async Task CompleteAsync() {
        await context.SaveChangesAsync();
    }
    
}