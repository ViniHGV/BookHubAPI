
using BookHub.API.Contract;
using BookHub.API.Dtos;
using BookHub.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookHub.API.Infra.Persistence.Repositories
{
    public class BookRepository(AppDbContext dbContext, ICategoryRepository categoryRepository, IAuthorRepository authorRepository) : IBookRepository
    {
        private readonly AppDbContext _dbContext = dbContext;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public async Task<bool> Create(CreateBookRequestDTO entityDTO)
        {
            var getCategoryById = await _categoryRepository.GetById(entityDTO.CategoryId, 0) ??
                throw new ArgumentException("A categoria informada não existe!");

            _ = await _authorRepository.GetById(entityDTO.AuthorId, 0) ??
                throw new ArgumentException("O Autor informado não existe!");

            var createdBook = new Book(
                entityDTO.Title,
                entityDTO.Sumarry,
                entityDTO.ISBN,
                entityDTO.YearPublication,
                getCategoryById.Name,
                entityDTO.AuthorId,
                entityDTO.CategoryId
            );

            try
            {
                await _dbContext.Books.AddAsync(createdBook);
                Save();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var bookById = await GetById(id, 0);
                _dbContext.Books.Remove(bookById);
                Save();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<Book>> GetAll(int pageSkip)
        {
            return await _dbContext.Books
            .Skip(pageSkip * 10)
            .Take(10)
            .ToListAsync();
        }

        public async Task<Book> GetById(int id, int pageSkip)
        {
            var bookById = await _dbContext.Books
            .Include(b => b.Category)
            .Include(b => b.Author)
            .FirstOrDefaultAsync(x => x.Id.Equals(id)) ??
                throw new ArgumentException("Livro não encontrado no sistema!");

            return bookById;
        }


        public async Task<Book> GetByTitle(string title)
        {
            var bookByTitle = await _dbContext.Books
            .FirstOrDefaultAsync(x => x.Title.ToLower().Equals(title.ToLower()));

            return bookByTitle;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task<bool> Update(int id, UpdateBookRequestDTO entityDTO)
        {
            var bookById = await GetById(id, 0) ??
                throw new ArgumentException("Livro não encontrado para edição!");

            var getCategoryById = await _categoryRepository.GetById(entityDTO.CategoryId, 0) ??
                throw new ArgumentException("A categoria informada não existe!");

            _ = await GetByTitle(entityDTO.Title) ??
                throw new ArgumentException("Esse livro já existe no sistema!");

            try
            {
                bookById.Title = entityDTO.Title;
                bookById.YearPublication = entityDTO.YearPublication;
                bookById.ISBN = entityDTO.ISBN;
                bookById.Sumarry = entityDTO.Sumarry;
                bookById.AuthorId = entityDTO.AuthorId;
                bookById.CategoryId = entityDTO.CategoryId;
                bookById.CategoryName = getCategoryById.Name;

                _dbContext.Books.Update(bookById);
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