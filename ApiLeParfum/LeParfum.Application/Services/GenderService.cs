using LeParfum.Domain.Entities;
using LeParfum.Application.Interfaces;
using LeParfum.Domain.Interfaces;
using LeParfum.Application.DTOs;

namespace LeParfum.Application.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<GenderDto> CreateAsync(CreateDto genderDto)
        {
            var genderList = await _genderRepository.GetAllGendersAsync();
            var genderExist = genderList.Any(b => b.Name.Equals(genderDto.Name, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrWhiteSpace(genderDto.Name))
            {
                throw new Exception("Digite um Gênero válido para cadastrar.");
            }

            else if (genderExist)
            {
                throw new Exception("Gênero já cadastrada");
            }

            var genderEntity = new GenderEntity
            {
                Name = genderDto.Name
            };

            var createdGender = await _genderRepository.CreateAsync(genderEntity);

            return new GenderDto
            {
                Id = createdGender.Id,
                Name = createdGender.Name
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);

            if (gender is null) throw new Exception("Marca não encontrada");

            await _genderRepository.DeleteAsync(gender);;
        }

        public async Task<IEnumerable<GenderEntity>> GetAllGendersAsync()
        {
            return await _genderRepository.GetAllGendersAsync();
        }

        public async Task<GenderEntity?> GetByIdAsync(Guid id)
        {
           return await _genderRepository.GetByIdAsync(id);
        }

        public async Task<GenderDto> UpdateAsync(GenderDto genderDto)
        {
            var gender = await _genderRepository.GetByIdAsync(genderDto.Id);

            if(gender is null) throw new Exception("Marca não encontrada!");

            if(string.IsNullOrWhiteSpace(genderDto.Name)) throw new Exception("O nome da marca não pode estar vazio");

            gender.Name = genderDto.Name;

            await _genderRepository.UpdadeAsync(gender);

            return new GenderDto
            {
                Id = gender.Id,
                Name = gender.Name
            };
        }
    }
}