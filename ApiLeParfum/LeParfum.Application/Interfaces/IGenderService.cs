using LeParfum.Application.DTOs;
using LeParfum.Domain.Entities;

namespace LeParfum.Application.Interfaces
{
    public interface IGenderService
    {
        public Task<IEnumerable<GenderEntity>> GetAllGendersAsync();
        public Task<GenderEntity?> GetByIdAsync(Guid id);
        public Task<GenderDto> CreateAsync(CreateDto genderDto);
        public Task DeleteAsync(Guid id);
        public Task<GenderDto> UpdateAsync(GenderDto genderDto);
    }
    
}