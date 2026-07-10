using LeParfum.Domain.Entities;
using LeParfum.Domain.Exceptions;
using LeParfum.Domain.Interfaces;
using LeParfum.Application.Interfaces;
using LeParfum.Application.DTOs;

namespace LeParfum.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
        {
           
            var productList = await _productRepository.GetAllProductsAsync();
            var productExists =  productList.Any(p => p.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase));
            
            if (productExists)
            {
                throw new ProductExceptions("Produto já cadastrado");
            }

            var productEntity = new ProductEntity
            {
                
                Name = dto.Name,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                Price = dto.Price,
                GenderId = dto.GenderId
            };

            var createdProduct = await _productRepository.CreateProductAsync(productEntity);

            return new ProductDto
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                BrandId = createdProduct.BrandId,
                CategoryId = createdProduct.CategoryId,
                Description = createdProduct.Description,
                Price = createdProduct.Price,
                GenderId = createdProduct.GenderId
            };             
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if(product == null) return false;

            await _productRepository.DeleteProductAsync(product);

            return true;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<ProductEntity> GetProductByIdAsync(Guid productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }

        public async Task<ProductEntity> UpdateProductAsync(ProductEntity product)
        {
            return await _productRepository.UpdateProductAsync(product);
        }
    }
}
