using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Shared.Domain.Services.Comunications;

namespace UPCLearningCenter.API.Learning.Domain.Services.Comunication;

public class TutorialResponse: BaseResponse<Tutorial>
{
    public TutorialResponse(string message) : base(message)
    {
    }

    public TutorialResponse(Tutorial resource) : base(resource)
    {
    }
}