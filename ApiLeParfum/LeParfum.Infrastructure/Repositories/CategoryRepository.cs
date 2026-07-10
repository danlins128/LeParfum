using LeParfum.Domain.Entities;
using LeParfum.Domain.Interfaces;
using LeParfum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LeParfum.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CategoryEntity> CreateAsync(CategoryEntity category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(CategoryEntity category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryEntity?> GetByIdAsync(Guid id)
        {
           return await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdadeAsync(CategoryEntity category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}