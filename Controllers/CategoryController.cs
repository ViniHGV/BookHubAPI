using BookHub.API.Dtos;
using BookHub.API.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] int pageSkip)
        {
            return Ok(await _categoryService.GetAllCategories(pageSkip));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
        {
            try
            {
                await _categoryService.CreateCategory(categoryDTO);
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
            try
            {
                var categoryById = await _categoryService.GetCategoryById(id, pageSkip);
                return Ok(categoryById);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id,
         [FromBody] CreateCategoryDTO entityDTO)
        {
            try
            {
                await _categoryService.UpdateCategory(id, entityDTO);
                return Ok("Categoria Editada com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
                return Ok("Categoria Editada com sucesso!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}