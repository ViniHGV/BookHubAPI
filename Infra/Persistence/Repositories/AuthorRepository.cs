using BookHub.API.Contract;
using BookHub.API.Dtos;
using BookHub.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookHub.API.Infra.Persistence.Repositories
{
    public class AuthorRepository(AppDbContext dbContext) : IAuthorRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Author> GetByName(string authorName)
        {
            var author = await _dbContext.Authors
            .FirstOrDefaultAsync(x => x.Name.ToLower().Equals(authorName.ToLower()));

            return author;
        }
        public async Task<bool> Delete(int id)
        {
            var author = await GetById(id, 0);

            try
            {
                _dbContext.Authors.Remove(author);
                Save();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public async Task<List<Author>> GetAll(int pageSkip)
        {
            var authorsList = await _dbContext.Authors
            .Skip(pageSkip * 10)
            .Take(10)
            .ToListAsync();
            return authorsList;
        }

        public async Task<Author> GetById(int id, int pageSkip)
        {
            var authorbyId = await _dbContext.Authors
            .Include(x => x.Books
                .Skip(pageSkip * 10)
                .Take(10))
            .Distinct()
            .FirstOrDefaultAsync(x => x.Id.Equals(id)) ??
                throw new ArgumentException("O Autor inserido não existe, verifique as informações!!");

            return authorbyId;
        }

        public async Task<bool> Update(int id, CreateAuthorRequestDTO entityDTO)
        {
            var authorbyId = await GetById(id, 0);

            try
            {
                authorbyId.Name = entityDTO.Name;
                _dbContext.Update(authorbyId);
                Save();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<bool> Create(CreateAuthorRequestDTO entityDTO)
        {
            var author = new Author(Name: entityDTO.Name);

            try
            {
                await _dbContext.Authors.AddAsync(author);
                Save();

                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}