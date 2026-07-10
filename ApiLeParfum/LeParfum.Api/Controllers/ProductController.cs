using LeParfum.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LeParfum.Application.DTOs;


namespace LeParfum.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {  
            await _productService.CreateProductAsync(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            var productResponseDto = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                BrandId = p.BrandId,
                BrandName = p.Brand.Name,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                GenderId = p.GenderId,
                GenderName = p.Gender.Name,
                IsHighLighted = p.IsHighlighted = false
            });

            return Ok(productResponseDto);
        }  

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            bool deletedSuccess = await _productService.DeleteProductAsync(id);

            if (!deletedSuccess)
            {
                return NotFound(new {message = "Produto não encontrado"});
            }
            return NoContent(); 
        }
        
    }
}