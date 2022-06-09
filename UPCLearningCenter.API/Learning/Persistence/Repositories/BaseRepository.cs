using UPCLearningCenter.API.Learning.Persistence.Contexts;

namespace UPCLearningCenter.API.Learning.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext context;

    public BaseRepository(AppDbContext context)
    {
        this.context = context;
    }
}