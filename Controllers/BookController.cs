using BookHub.API.Dtos;
using BookHub.API.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery] int pageSkip)
        {
            return Ok(await _bookService.GetAllBooks(pageSkip));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequestDTO requestDTO)
        {
            try
            {
                await _bookService.CreateBook(requestDTO);
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
            try
            {
                var bookById = await _bookService.GetBookById(id);
                return Ok(bookById);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id,
             [FromBody] UpdateBookRequestDTO updateBookRequestDTO)
        {
            try
            {
                await _bookService.UpdateBook(id, updateBookRequestDTO);
                return Ok("Livro Editado com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            try
            {
                await _bookService.RemoveBook(id);
                return Ok("Livro deletado com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("filterby")]
        public async Task<IActionResult> GetBooksByFilter([FromQuery] string filter)
        {
            try
            {
                var books = await _bookService.GetBooksByFilter(filter);
                return Ok(books);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}