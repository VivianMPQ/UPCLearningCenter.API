using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Services;
using UPCLearningCenter.API.Learning.Resources;

namespace UPCLearningCenter.API.Learning.Controllers;

//decoramos
[ApiController]
[Route("[controller]")] //  ./Categories
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

//inyeccion de dependencia por consy¿tructor
//generate -> constructor
    public CategoriesController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryResource>> GetAll()
    {
        var categories = await _categoryService.ListAsync();
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
    }
}