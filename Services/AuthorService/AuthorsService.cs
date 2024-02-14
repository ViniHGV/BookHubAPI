using BookHub.API.Contract;
using BookHub.API.Dtos;
using BookHub.API.Entities;

namespace BookHub.API.Services.AuthorService
{
    public class AuthorsService(IAuthorRepository authorsRepository) : IAuthorsService
    {
        private readonly IAuthorRepository _authorsRepository = authorsRepository;

        public async Task<bool> CreateAuthor(CreateAuthorRequestDTO authorRequestDTO)
        {
            var searchAutor = await _authorsRepository.GetByName(authorRequestDTO.Name);

            if (searchAutor != null)
                throw new ArgumentException("Autor já existe no sistema!!");

            try
            {
                await _authorsRepository.Create(authorRequestDTO);

                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            return await _authorsRepository.Delete(id);
        }

        public async Task<List<Author>> GetAllAuthors(int pageSkip)
        {
            return await _authorsRepository.GetAll(pageSkip);
        }

        public async Task<Author> GetAuthorById(int id, int pageSkip)
        {
            return await _authorsRepository.GetById(id, pageSkip);
        }

        public async Task<bool> UpdateAuthor(int id, CreateAuthorRequestDTO authorRequestDTO)
        {
            var authorByName = await _authorsRepository.GetByName(authorRequestDTO.Name);

            return authorByName != null
            ? throw new ArgumentException("Autor já existe no sistema!")
            : await _authorsRepository.Update(id, authorRequestDTO);
        }
    }
}