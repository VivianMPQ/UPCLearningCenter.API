using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Learning.Domain.Repositories;
using UPCLearningCenter.API.Learning.Domain.Services;
using UPCLearningCenter.API.Learning.Domain.Services.Comunication;

namespace UPCLearningCenter.API.Learning.Services;

public class CategoryService: ICategoryService
{
    //generamos un constructor en category service
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public  Task<IEnumerable<Category>> ListAsync()
    {
        return  _categoryRepository.ListAsync();
    }

    public async Task<CategoryResponse> SaveAsync(Category category)
    {
        try {
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CompleteAsync();
            return new CategoryResponse(category);
        } catch (Exception e) {
            return new CategoryResponse($"An error occurred while saving the forecast: {e.Message}");
        }
    }

    public async Task<CategoryResponse> UpdateAsync(long id, Category category)
    {
        var current = await _categoryRepository.FinByIdAsync(id);
        if (current == null) {
            return new CategoryResponse("Category not found");
        }

        current.Name = category.Name;

        try {
            _categoryRepository.Update(current);
            await _unitOfWork.CompleteAsync();
            return new CategoryResponse(current);
        } catch (Exception e) {
            return new CategoryResponse($"An error occurred while updating the forecast: {e.Message}");
        }
    }

    public async Task<CategoryResponse> DeleteAsync(long id)
    {
        var current = await _categoryRepository.FinByIdAsync(id);
        if (current == null)
        {
            return new CategoryResponse("Category not found");
        }

        try {
            _categoryRepository.Remove(current);
            await _unitOfWork.CompleteAsync();
            return new CategoryResponse(current);
        } catch (Exception e) {
            return new CategoryResponse($"An error occurred while deleting the forecast: {e.Message}");
        }
    }
    
}