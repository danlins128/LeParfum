using LeParfum.Application.Interfaces;
using LeParfum.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LeParfum.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var brands = await _brandService.GetAllBrandsAsync();
                var brandDto = brands.Select(b => new BrandDto
                {
                    Id = b.Id,
                    Name = b.Name
                });

                return Ok(brandDto);
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
                var brand = await _brandService.GetByIdAsync(id);
                if (brand == null) NotFound();

                return Ok(brand);
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
                var newBrand = await _brandService.CreateAsync(createDto);
                return Ok(newBrand);

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
                await _brandService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id,BrandDto brandDto)
        {
            try
            {
                brandDto.Id = id;

                var brandUpdated = await _brandService.UpdateAsync(brandDto);

                return Ok(brandUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}