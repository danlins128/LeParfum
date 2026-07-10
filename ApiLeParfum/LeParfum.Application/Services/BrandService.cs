using LeParfum.Domain.Entities;
using LeParfum.Domain.Interfaces;
using LeParfum.Application.Interfaces;
using LeParfum.Application.DTOs;

namespace LeParfum.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandDto> CreateAsync(CreateDto brandDto)
        {
            var brandList = await _brandRepository.GetAllBrandsAsync();
            var brandExist = brandList.Any(b => b.Name.Equals(brandDto.Name, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrWhiteSpace(brandDto.Name))
            {
                throw new Exception ("Digite o nome de uma marca válida para cadastrar.");
            }
            
            else if (brandExist)
            {
                throw new Exception("Marca já cadastrada");
            }

            var brandEntity = new BrandEntity
            {
                Name = brandDto.Name
            };

            var createdBrand = await _brandRepository.CreateAsync(brandEntity);

            return new BrandDto
            {
                Id = createdBrand.Id,
                Name = createdBrand.Name
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            if (brand is null) throw new Exception("Marca não encontrada");

            await _brandRepository.DeleteAsync(brand);
        }

        public async Task<IEnumerable<BrandEntity>> GetAllBrandsAsync()
        {
            return await _brandRepository.GetAllBrandsAsync();
        }       

        public async Task<BrandEntity?> GetByIdAsync(Guid id)
        {
            return await _brandRepository.GetByIdAsync(id);
        }

        public async Task<BrandDto> UpdateAsync(BrandDto brandDto)
        {
            var brand = await _brandRepository.GetByIdAsync(brandDto.Id);

            if(brand is null) throw new Exception("Marca não encontrada!");

            if(string.IsNullOrWhiteSpace(brandDto.Name)) throw new Exception("O nome da marca não pode estar vazio");

            brand.Name = brandDto.Name;

            await _brandRepository.UpdadeAsync(brand);

            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }
    }
}