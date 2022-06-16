using AutoMapper;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Resources;

namespace UPCLearningCenter.API.Learning.Mapping;
public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Category, CategoryResource>();
        CreateMap<Tutorial, TutorialResource>();
    }
}