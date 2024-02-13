using BookHub.API.Dtos;
using BookHub.API.Entities;

namespace BookHub.API.Contract
{
    public interface IBookRepository : IGenericRepository<Book, CreateBookRequestDTO, UpdateBookRequestDTO>
    {
        Task<Book> GetByTitle(string title);
    }
}