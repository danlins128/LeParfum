using LeParfum.Domain.Entities;
using LeParfum.Application.Interfaces;
using LeParfum.Domain.Interfaces;
using LeParfum.Application.DTOs;

namespace LeParfum.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> CreateAsync(CreateDto createDto)
        {
            var categoryList = await _categoryRepository.GetAllCategoriesAsync();
            var categoryExist = categoryList.Any(c => c.Name.Equals(createDto.Name, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrWhiteSpace(createDto.Name))
            {
                throw new Exception("Digite o nome de uma categoria válida");
            }
            else if (categoryExist)
            {
                throw new Exception("Categoria já cadastrada");
            }

            var categoryEntity = new CategoryEntity
            {
                Name = createDto.Name
            };

            var createdCategory = await _categoryRepository.CreateAsync(categoryEntity);

            return new CategoryDto
            {
                Id = createdCategory.Id,
                Name = createdCategory.Name
            };

        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category is null) throw new Exception("Categoria não encontrada.");

            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<CategoryEntity?> GetByIdAsync(Guid id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryDto.Id);

            if (category is null) throw new Exception("Categoria não encontrada.");

            if (string.IsNullOrWhiteSpace(category.Name)) throw new Exception("O nome da marca não pode estar vazio");

            await _categoryRepository.UpdadeAsync(category);

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}