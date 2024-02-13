
using BookHub.API.Dtos;
using BookHub.API.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IAuthorsService _authorsService) : ControllerBase
    {
        private readonly IAuthorsService _authorsService = _authorsService;

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors([FromQuery] int pageSkip)
        {
            return Ok(await _authorsService.GetAllAuthors(pageSkip));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequestDTO authorRequestDTO)
        {
            await _authorsService.CreateAuthor(authorRequestDTO);

            try
            {
                return Ok("Autor Criado com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] int id)
        {
            var authorById = await _authorsService.GetAuthorById(id);

            try
            {
                return Ok(authorById);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditAuthor([FromRoute] int id,
         [FromBody] CreateAuthorRequestDTO authorRequestDTO)
        {
            await _authorsService.UpdateAuthor(id, authorRequestDTO);

            try
            {
                return Ok("Usuário editado com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }
    }
}