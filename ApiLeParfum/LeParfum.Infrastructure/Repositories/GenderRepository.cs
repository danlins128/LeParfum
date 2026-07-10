using LeParfum.Domain.Entities;
using LeParfum.Domain.Interfaces;
using LeParfum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LeParfum.Infrastructure.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDbContext _context;
        public GenderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenderEntity> CreateAsync(GenderEntity gender)
        {
            await _context.AddAsync(gender);
            await _context.SaveChangesAsync();
            return gender;
        }

        public async Task DeleteAsync(GenderEntity gender)
        {
            _context.Remove(gender);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<GenderEntity>> GetAllGendersAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<GenderEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Genders
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task UpdadeAsync(GenderEntity gender)
        {
            _context.Update(gender);
            await _context.SaveChangesAsync();
        }
    }
}