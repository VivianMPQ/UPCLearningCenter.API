using AutoMapper;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Resources;

namespace UPCLearningCenter.API.Learning.Mapping;
public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCategoryResource, Category>();
        CreateMap<SaveTutorialResource, Tutorial>();
    }
}