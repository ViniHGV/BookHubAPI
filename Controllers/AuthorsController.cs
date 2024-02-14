
using BookHub.API.Dtos;
using BookHub.API.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IAuthorsService authorsService) : ControllerBase
    {
        private readonly IAuthorsService _authorsService = authorsService;

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors([FromQuery] int pageSkip)
        {
            return Ok(await _authorsService.GetAllAuthors(pageSkip));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequestDTO authorRequestDTO)
        {
            try
            {
                await _authorsService.CreateAuthor(authorRequestDTO);
                return Ok("Autor Criado com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] int id, [FromQuery] int pageSkip)
        {
            try
            {
                var authorById = await _authorsService.GetAuthorById(id, pageSkip);
                return Ok(authorById);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAuthor([FromRoute] int id,
         [FromBody] CreateAuthorRequestDTO authorRequestDTO)
        {
            try
            {
                await _authorsService.UpdateAuthor(id, authorRequestDTO);
                return Ok("Usuário editado com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        {
            try
            {
                await _authorsService.DeleteAuthor(id);
                return Ok("Usuário deletado com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

    }
}