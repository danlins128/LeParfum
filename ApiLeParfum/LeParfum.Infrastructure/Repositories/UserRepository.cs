using LeParfum.Domain.Entities;
using LeParfum.Domain.Interfaces;
using LeParfum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LeParfum.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserEntity?> AddUserAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity?> DeleteUserAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            
            _context.Users.Remove(user!);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity?> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<UserEntity?> GetUsernameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync<UserEntity>(u => u.UserName == userName);
        }
    }
}