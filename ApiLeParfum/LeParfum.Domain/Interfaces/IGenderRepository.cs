using LeParfum.Domain.Entities;

namespace LeParfum.Domain.Interfaces
{
    public interface IGenderRepository
    {
        public Task<IEnumerable<GenderEntity>> GetAllGendersAsync();
        public Task<GenderEntity?> GetByIdAsync(Guid id);
        public Task<GenderEntity> CreateAsync(GenderEntity gender);
        public Task UpdadeAsync(GenderEntity gender);
        public Task DeleteAsync(GenderEntity gender);
    }
}