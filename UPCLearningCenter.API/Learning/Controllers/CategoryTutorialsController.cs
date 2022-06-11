using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Services;
using UPCLearningCenter.API.Learning.Resources;

namespace UPCLearningCenter.API.Learning.Controllers;


[ApiController]
[Route("/api/v1/categories/{categoryId}/tutorials")]
[Produces(MediaTypeNames.Application.Json)]
public class CategoryTutorialsController
{
    private readonly ITutorialService _tutorialService;
    private readonly IMapper _mapper;

    public CategoryTutorialsController(ITutorialService tutorialService, IMapper mapper)
    {
        _tutorialService = tutorialService;
        _mapper = mapper;
    }
    
    [HttpGet]
    // [SwaggerOperation(
    //     Summary = "Get All Tutorials for given Category",
    //     Description = "Get existing Tutorials associated with the specified Category",
    //     OperationId = "GetCategoryTutorials",
    //     Tags = new[] { "Categories" }
    // )]
    public async Task<IEnumerable<TutorialResource>> GetAllByCategoryIdAsync(long categoryId)
    {
        var tutorials = await _tutorialService.ListByCategoryIdAsync(categoryId);
        var resources = _mapper.Map<IEnumerable<Tutorial>, IEnumerable<TutorialResource>>(tutorials);
        return resources;
    }
    
    
    
}