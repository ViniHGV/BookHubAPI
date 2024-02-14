using BookHub.API.Contract;
using BookHub.API.Dtos;
using BookHub.API.Entities;

namespace BookHub.API.Services.CategoryService
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<List<Category>> GetAllCategories(int pageSkip)
        {
            return await _categoryRepository.GetAll(pageSkip);
        }

        public async Task<Category> GetCategoryById(int id, int pageSkip)
        {
            return await _categoryRepository.GetById(id, pageSkip);
        }

        public async Task<bool> CreateCategory(CreateCategoryDTO categoryRequestDTO)
        {
            var searchCategoryByName = await _categoryRepository.GetByName(categoryRequestDTO.Name);

            return searchCategoryByName != null
                ? throw new ArgumentException($"A categoria {categoryRequestDTO.Name} já existe!")
                : await _categoryRepository.Create(categoryRequestDTO);
        }

        public async Task<bool> UpdateCategory(int id, CreateCategoryDTO categoryRequestDTO)
        {
            var categoriesByName = await _categoryRepository.GetByName(categoryRequestDTO.Name);

            return categoriesByName != null
                ? throw new ArgumentException($"A categoria {categoryRequestDTO.Name} já existe!")
                : await _categoryRepository.Update(id, categoryRequestDTO);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _categoryRepository.Delete(id);
        }
    }
}