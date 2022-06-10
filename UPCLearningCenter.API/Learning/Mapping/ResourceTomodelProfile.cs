using AutoMapper;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Resources;

namespace UPCLearningCenter.API.Learning.Mapping;

//igual que los anteriores es un descendiente d eprofile de automapper
//generar un constructor
public class ResourceTomodelProfile : Profile
{
    public ResourceTomodelProfile()
    {
        CreateMap<SaveCategoryResponse, Category>();
        CreateMap<SaveTutorialResource, Tutorial>();
    }
}