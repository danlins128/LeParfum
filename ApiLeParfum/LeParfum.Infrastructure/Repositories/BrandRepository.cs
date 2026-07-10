using LeParfum.Domain.Entities;
using LeParfum.Domain.Interfaces;
using LeParfum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LeParfum.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BrandEntity> CreateAsync(BrandEntity brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task DeleteAsync(BrandEntity brand)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BrandEntity>> GetAllBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<BrandEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Brands
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdadeAsync(BrandEntity brand)
        {
            _context.Brands.Update(brand);

            await _context.SaveChangesAsync();
        }
    }
}