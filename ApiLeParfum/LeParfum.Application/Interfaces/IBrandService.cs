using LeParfum.Application.DTOs;
using LeParfum.Domain.Entities;

namespace LeParfum.Application.Interfaces
{
    public interface IBrandService
    {
        public Task<IEnumerable<BrandEntity>> GetAllBrandsAsync();
        public Task<BrandEntity?> GetByIdAsync(Guid id);
        public Task<BrandDto> CreateAsync(CreateDto brandDto);
        public Task DeleteAsync(Guid id);
        public Task<BrandDto> UpdateAsync(BrandDto brandDto);
    }
}