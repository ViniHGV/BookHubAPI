
using BookHub.API.Dtos;
using BookHub.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService _authorsService) =>
            this._authorsService = _authorsService;

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var ReturnForGetAllAuthors = await _authorsService.GetAllAuthors();
            return Ok(ReturnForGetAllAuthors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorRequestDTO authorRequestDTO)
        {
            await _authorsService.CreateAuthor(authorRequestDTO);
            return Ok("Autor Criado com sucesso!");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] int id)
        {
            var authorById = await _authorsService.GetAuthorById(id);

            if (authorById == null)
                return NotFound("Usuário não encontrado!");

            return Ok(authorById);
        }
    }
}