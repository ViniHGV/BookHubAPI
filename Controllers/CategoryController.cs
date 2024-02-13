using BookHub.API.Dtos;
using BookHub.API.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(CategoryService _categoryService) : ControllerBase
    {
        private readonly CategoryService _categoryService = _categoryService;

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] int pageSkip)
        {
            return Ok(await _categoryService.GetAllCategories(pageSkip));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
        {
            await _categoryService.CreateCategory(categoryDTO);
            try
            {
                return Ok($"Categoria {categoryDTO.Name} criada com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id, [FromQuery] int pageSkip)
        {
            var categoryById = await _categoryService.GetCategoryById(id, pageSkip);

            try
            {
                return Ok(categoryById);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}