using LeParfum.Domain.Entities;

namespace LeParfum.Domain.Interfaces
{
    public interface IBrandRepository
    {
        public Task<IEnumerable<BrandEntity>> GetAllBrandsAsync();
        public Task<BrandEntity?> GetByIdAsync(Guid id);
        public Task<BrandEntity> CreateAsync(BrandEntity brand);
        public Task UpdadeAsync(BrandEntity brand);
        public Task DeleteAsync(BrandEntity brand);
    }
}