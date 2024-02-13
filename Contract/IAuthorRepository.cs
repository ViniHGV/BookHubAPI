using BookHub.API.Dtos;
using BookHub.API.Entities;

namespace BookHub.API.Contract
{
    public interface IAuthorRepository : IGenericRepository<Author, CreateAuthorRequestDTO, CreateAuthorRequestDTO>
    {
        Task<Author> GetByName(string name);
    }
}