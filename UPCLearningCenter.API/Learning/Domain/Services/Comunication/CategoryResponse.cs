using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Shared.Domain.Services.Comunications;

namespace UPCLearningCenter.API.Learning.Domain.Services.Comunication;

public class CategoryResponse: BaseResponse<Category>
{
    public CategoryResponse(string message) : base(message)
    {
    }

    public CategoryResponse(Category resource) : base(resource)
    {
    }
}