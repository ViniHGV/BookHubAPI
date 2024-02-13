using BookHub.API.Dtos;
using BookHub.API.Entities;
using BookHub.API.Infra.Persistence.Repositories;

namespace BookHub.API.Services.BookService
{
    public class BookService(BookRepository _bookRepository) : IBookService
    {
        private BookRepository _bookRepository { get; set; } = _bookRepository;

        public async Task<bool> CreateBook(CreateBookRequestDTO BookRequestDTO)
        {
            var searchByTitle = await _bookRepository.GetByTitle(BookRequestDTO.Title);

            if (searchByTitle != null)
                throw new ArgumentException($"O livro {BookRequestDTO.Title} já existe no sistema!");

            try
            {
                await _bookRepository.Create(BookRequestDTO);
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<Book>> GetAllBooks(int pageSkip)
        {
            return await _bookRepository.GetAll(pageSkip);
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetById(id, 0);
        }

        public async Task<bool> UpdateBook(int id, UpdateBookRequestDTO BookRequestDTO)
        {
            return await _bookRepository.Update(id, BookRequestDTO);
        }
    }
}