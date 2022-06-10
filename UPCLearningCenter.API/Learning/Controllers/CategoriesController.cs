using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Services;
using UPCLearningCenter.API.Learning.Resources;
using UPCLearningCenter.API.Shared.Extensions;

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
    //despues de completar casi toda la implementacion
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SaveCategoryResource resource) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var category = _mapper.Map<SaveCategoryResource, Category>(resource);
        var result = await _categoryService.SaveAsync(category);
        if (!result.Success)
            return BadRequest(result.Message);
        //si es exitoso o success
        var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
        return Ok(categoryResource);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] SaveCategoryResource resource) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var category = _mapper.Map<SaveCategoryResource, Category>(resource);
        var result = await _categoryService.UpdateAsync(id, category);
        
        if (!result.Success)
            return BadRequest(result.Message);
        //si es exitoso o success
        var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
        return Ok(categoryResource);
        
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id) {
        var result = await _categoryService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        //si es exitoso o success
        var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
        return Ok(categoryResource);

    }
    
    
    
}