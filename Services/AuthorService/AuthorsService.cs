using BookHub.API.Dtos;
using BookHub.API.Entities;
using BookHub.API.Infra.Persistence.Repositories;

namespace BookHub.API.Services.AuthorService
{
    public class AuthorsService(AuthorsRepository _authorsRepository) : IAuthorsService
    {
        private AuthorsRepository _authorsRepository { get; set; } = _authorsRepository;

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

        public async Task<List<Author>> GetAllAuthors(int pageSkip)
        {
            return await _authorsRepository.GetAll(pageSkip);
        }

        public async Task<Author> GetAuthorById(int id)
        {
            var author = await _authorsRepository.GetById(id, 0);

            if (author == null)
                throw new ArgumentException("Autor não encontrado, insira um Autor que existe!");

            return author;
        }

        public async Task<bool> UpdateAuthor(int id, CreateAuthorRequestDTO authorRequestDTO)
        {
            return await _authorsRepository.Update(id, authorRequestDTO);
        }
    }
}