using Microsoft.AspNetCore.Mvc;
using LeParfum.Application.Interfaces;
using LeParfum.Application.DTOs;
using Microsoft.AspNetCore.Mvc.ActionConstraints;


namespace LeParfum.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                var categoryDto = categories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                });
                return Ok(categoryDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);

                return Ok(category);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateDto createDto)
        {
            try
            {
                var newCategory = await _categoryService.CreateAsync(createDto);
                return Ok(newCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, CategoryDto categoryDto)
        {
            try
            {
                categoryDto.Id = id;

                var categoryUpdated = await _categoryService.UpdateAsync(categoryDto);

                return Ok(categoryUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}