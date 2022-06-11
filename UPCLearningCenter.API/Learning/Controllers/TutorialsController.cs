using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Services;
using UPCLearningCenter.API.Learning.Resources;

namespace UPCLearningCenter.API.Learning.Controllers;

[ApiController]
[Route("[controller]")]
public class TutorialsController: ControllerBase
{
    private readonly ITutorialService _tutorialService;
    private readonly IMapper _mapper;


    public TutorialsController(ITutorialService tutorialService, IMapper mapper)
    {
        _tutorialService = tutorialService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TutorialResource>> GetAllAsync()
    {
        var tutorials = await _tutorialService.ListAsync();
        return _mapper.Map<IEnumerable<Tutorial>, IEnumerable<TutorialResource>>(tutorials);

    }

}