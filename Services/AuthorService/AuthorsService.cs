using BookHub.API.Dtos;
using BookHub.API.Entities;
using BookHub.API.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookHub.API.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly AppDbContext _appDbContext;
        public AuthorsService(AppDbContext _appDbContext) =>
            this._appDbContext = _appDbContext;

        public async Task<Author> CreateAuthor(AuthorRequestDTO authorRequestDTO)
        {
            var newAuthor = new Author
            {
                Name = authorRequestDTO.Name
            };

            try
            {
                await _appDbContext.Authors.AddAsync(newAuthor);
                await _appDbContext.SaveChangesAsync();

                return newAuthor;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await _appDbContext.Authors
                .Include(x => x.Books)
                .ToListAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _appDbContext.Authors
                .Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}