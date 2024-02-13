using BookHub.API.Dtos;
using BookHub.API.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(BookService _bookService) : ControllerBase
    {
        private readonly BookService _bookService = _bookService;

        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery] int pageSkip)
        {
            var allBooks = await _bookService.GetAllBooks(pageSkip);

            return Ok(allBooks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequestDTO requestDTO)
        {
            await _bookService.CreateBook(requestDTO);

            try
            {
                return Ok("Livro adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var bookById = await _bookService.GetBookById(id);

            try
            {
                return Ok(bookById);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}