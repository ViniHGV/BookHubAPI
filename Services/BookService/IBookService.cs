using BookHub.API.Dtos;
using BookHub.API.Entities;

namespace BookHub.API.Services.BookService
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks(int pageSkip);
        Task<Book> GetBookById(int id);
        Task<bool> CreateBook(CreateBookRequestDTO BookRequestDTO);
        Task<bool> UpdateBook(int id, UpdateBookRequestDTO BookRequestDTO);
        Task<bool> RemoveBook(int id);
    }
}