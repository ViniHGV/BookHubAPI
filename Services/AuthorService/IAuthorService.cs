using BookHub.API.Dtos;
using BookHub.API.Entities;

namespace BookHub.API.Services.AuthorService
{
    public interface IAuthorsService
    {
        Task<List<Author>> GetAllAuthors(int pageSkip);
        Task<Author> GetAuthorById(int id);
        Task<bool> CreateAuthor(CreateAuthorRequestDTO authorRequestDTO);
        Task<bool> UpdateAuthor(int id, CreateAuthorRequestDTO authorRequestDTO);
    }
}