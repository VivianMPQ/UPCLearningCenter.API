using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Repositories;
using UPCLearningCenter.API.Learning.Domain.Services;
using UPCLearningCenter.API.Learning.Domain.Services.Comunication;

namespace UPCLearningCenter.API.Learning.Services;

public class TutorialService: ITutorialService
{
    private readonly ITutorialRepository _tutorialRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly ICategoryRepository _categoryRepository;
//llamamos al constructor
    public TutorialService(ITutorialRepository tutorialRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _tutorialRepository = tutorialRepository;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Tutorial>> ListAsync()
    {
        return await _tutorialRepository.ListAsync();
    }

    public async Task<IEnumerable<Tutorial>> ListByCategoryIdAsync(long categoryId)
    {
        return await _tutorialRepository.FindByCategoryIdAsync(categoryId);
    }

    public async Task<TutorialResponse> SaveAsync(Tutorial tutorial)
    {
        //validate categoryid
        var existingCategory = await _categoryRepository.FinByIdAsync(tutorial.CategoryId);
        if (existingCategory == null)
        {
            return new TutorialResponse("Invalid Category");
        }
        
        //validate name
        var existingTutorialWithTitle = await _tutorialRepository.FindByTitleAsync(tutorial.Title);
        if (existingTutorialWithTitle != null)
        {
            return new TutorialResponse("Tutorial title already exists.");
        }

        try
        {
            //add tutorial
            await _tutorialRepository.AddAsync(tutorial);
            //complete transantion
            await _unitOfWork.CompleteAsync();
            //return response
            return new TutorialResponse(tutorial);


        }
        //en caso hay problemas
        catch (Exception e)
        {
            //error handling
            return new TutorialResponse($"An error occurred while saving the tutorial: {e.Message}");
        }
        
        //update
        
        //complete update
        //error handling

    }

    public async Task<TutorialResponse> UpdateAsync(long tutorialId, Tutorial tutorial)
    {
        var existingTutorial = await _tutorialRepository.FinByIdAsync(tutorialId);
        //validate tutorial
        if (existingTutorial == null)
            return new TutorialResponse("Tutorial not found");
       
        // Validate CategoryId
        var existingCategory = await _categoryRepository.FinByIdAsync(tutorial.CategoryId);
        if (existingCategory == null)
            return new TutorialResponse("Invalid Category");
        
        //validate title
        var existingTutorialWithTitle = await _tutorialRepository.FindByTitleAsync(tutorial.Title);
        if (existingTutorialWithTitle != null&& existingTutorialWithTitle.id!=existingTutorial.id)
            return new TutorialResponse("Tutorial title already exists.");
        
        //modify files
        existingTutorial.Title = tutorial.Title;
        existingTutorial.Description = tutorial.Description;

        try
        {
            _tutorialRepository.Update(existingTutorial);
            await _unitOfWork.CompleteAsync();

            return new TutorialResponse(existingTutorial);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new TutorialResponse($"An error occurred while updating the tutorial: {e.Message}");
        }
        
    }

    public async Task<TutorialResponse> DeleteAsync(long tutorialId)
    {
        var existingTutorial = await _tutorialRepository.FinByIdAsync(tutorialId);
        
        // Validate Tutorial

        if (existingTutorial == null)
            return new TutorialResponse("Tutorial not found.");
        
        try
        {
            _tutorialRepository.Remove(existingTutorial);
            await _unitOfWork.CompleteAsync();

            return new TutorialResponse(existingTutorial);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new TutorialResponse($"An error occurred while deleting the tutorial: {e.Message}");
        }

    }
    
}