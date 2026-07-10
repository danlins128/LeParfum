using LeParfum.Application.DTOs;
using LeParfum.Domain.Entities;

namespace LeParfum.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync();
        public Task<CategoryEntity?> GetByIdAsync(Guid id);
        public Task<CategoryDto> CreateAsync(CreateDto createDto);
        public Task DeleteAsync(Guid id);
        public Task<CategoryDto> UpdateAsync(CategoryDto
        categoryDto);
    }
}