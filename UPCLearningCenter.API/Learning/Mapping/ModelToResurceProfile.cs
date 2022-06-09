﻿using AutoMapper;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Resources;

namespace UPCLearningCenter.API.Learning.Mapping;

//hereda de profile de automapper
//creamos un constructor
public class ModelToResurceProfile : Profile
{
    public ModelToResurceProfile()
    {
        CreateMap<Category, CategoryResource>();
    }
}