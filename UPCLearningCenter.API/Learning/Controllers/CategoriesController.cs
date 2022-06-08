using Microsoft.AspNetCore.Mvc;
using UPCLearningCenter.API.Learning.Domain.Services;

namespace UPCLearningCenter.API.Learning.Controllers;

//decoramos
[ApiController]
[Route("[controller]")]  //  ./Categories
public class CategoriesController: ControllerBase
{
    private readonly ICategoryService _categoryService;
    

//inyeccion de dependencia por consy¿tructor
//generate -> constructor
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    
    
    
}