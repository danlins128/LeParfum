using LeParfum.Domain.Entities;
using LeParfum.Application.DTOs;

namespace LeParfum.Application.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDto> CreateProductAsync(CreateProductDto dto);
        public Task<ProductEntity?> GetProductByIdAsync(Guid productId);
        public Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
        public Task<ProductDto> UpdateProductAsync(Guid id, CreateProductDto dto);
        public Task<bool> DeleteProductAsync(Guid productId);
    }
}