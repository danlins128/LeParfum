using LeParfum.Application.DTOs;
using LeParfum.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeParfum.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;
        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            try
            {
                var genders = await _genderService.GetAllGendersAsync();
                var genderDto = genders.Select(g => new GenderDto
                {
                    Id = g.Id,
                    Name = g.Name
                });
                return Ok(genderDto);

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
                var category = await _genderService.GetByIdAsync(id);

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
                var newCategory = await _genderService.CreateAsync(createDto);
                return Ok(newCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, GenderDto genderDto)
        {
            try
            {
                genderDto.Id = id;

                var categoryUpdated = await _genderService.UpdateAsync(genderDto);

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
                await _genderService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}