using BookHub.API.Dtos;
using BookHub.API.Entities;

namespace BookHub.API.Services
{
    public interface IAuthorsService
    {
        Task<List<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task<Author> CreateAuthor(AuthorRequestDTO authorRequestDTO);
    }
}