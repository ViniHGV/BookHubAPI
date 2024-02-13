using BookHub.API.Dtos;
using BookHub.API.Entities;

namespace BookHub.API.Contract
{
    public interface ICategoryRepository : IGenericRepository<Category, CreateCategoryDTO, CreateCategoryDTO>
    {
        Task<Category> GetByName(string name);
    }
}