using BCrypt.Net;
using LeParfum.Domain.Interfaces;

namespace LeParfum.Infrastructure.Security.Cryptography
{
    public class PasswordHasher : IPasswordHasher
    {
        public async Task<string> HashPasswordAsync(string password)
        {
            return await Task.FromResult(BCrypt.Net.BCrypt.HashPassword(password));
        }

        public async Task<bool> VerifyPasswordAsync(string password, string hash)
        {
            return await Task.FromResult(BCrypt.Net.BCrypt.Verify(password, hash));
        }
    }
}