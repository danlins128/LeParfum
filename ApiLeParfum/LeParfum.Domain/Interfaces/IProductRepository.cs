using LeParfum.Domain.Entities;

namespace LeParfum.Domain.Interfaces
{
    public interface IProductRepository
    {
        public Task<ProductEntity> CreateProductAsync(ProductEntity product);
        public Task<ProductEntity?> GetProductByIdAsync(Guid productId);
        public Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
        public Task<ProductEntity> UpdateProductAsync(ProductEntity product);
        public Task DeleteProductAsync(ProductEntity product);
    }
}