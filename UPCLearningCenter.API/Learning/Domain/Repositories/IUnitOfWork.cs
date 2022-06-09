namespace UPCLearningCenter.API.Learning.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}