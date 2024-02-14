using BookHub.API.Dtos;
using BookHub.API.Entities;

namespace BookHub.API.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories(int pageSkip);
        Task<Category> GetCategoryById(int id, int pageSkip);
        Task<bool> CreateCategory(CreateCategoryDTO categoryRequestDTO);
        Task<bool> UpdateCategory(int id, CreateCategoryDTO categoryRequestDTO);
        Task<bool> DeleteCategory(int id);
    }
}