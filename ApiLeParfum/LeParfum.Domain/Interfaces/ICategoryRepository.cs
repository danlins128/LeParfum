using LeParfum.Domain.Entities;

namespace LeParfum.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync();
        public Task<CategoryEntity?> GetByIdAsync(Guid id);
        public Task<CategoryEntity> CreateAsync(CategoryEntity category);
        public Task UpdadeAsync(CategoryEntity category);
        public Task DeleteAsync(CategoryEntity category);
    }
}