using LeParfum.Domain.Entities;
using LeParfum.Domain.Interfaces;
using LeParfum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LeParfum.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> CreateProductAsync(ProductEntity productDto)
        {
            await _context.Products.AddAsync(productDto);
            await _context.SaveChangesAsync();
            return productDto;
        }

        public async Task DeleteProductAsync(ProductEntity product)
        {
            
             _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            await Task.CompletedTask;
            
        }
        

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.Gender)
            .ToListAsync();
        }

        public async Task<ProductEntity?> GetProductByIdAsync(Guid productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task<ProductEntity> UpdateProductAsync(ProductEntity productDto)
        {
            _context.Products.Update(productDto);
            await _context.SaveChangesAsync();
            return productDto;
        }
    }
}