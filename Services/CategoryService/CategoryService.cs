using BookHub.API.Dtos;
using BookHub.API.Entities;
using BookHub.API.Infra.Persistence.Repositories;

namespace BookHub.API.Services.CategoryService
{
    public class CategoryService(CategoryRepository _categoryRepository) : ICategoryService
    {
        private CategoryRepository _categoryRepository { get; set; } = _categoryRepository;

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

            if (searchCategoryByName != null)
                throw new ArgumentException($"A categoria {categoryRequestDTO.Name} já existe!");

            return await _categoryRepository.Create(categoryRequestDTO);
        }

        public async Task<bool> UpdateCategory(int id, CreateCategoryDTO categoryRequestDTO)
        {
            var searchCategoryByName = await _categoryRepository.GetByName(categoryRequestDTO.Name);

            if (searchCategoryByName != null)
                throw new ArgumentException($"A categoria {categoryRequestDTO.Name} já existe!");

            return await _categoryRepository.Update(id, categoryRequestDTO);
        }
    }
}