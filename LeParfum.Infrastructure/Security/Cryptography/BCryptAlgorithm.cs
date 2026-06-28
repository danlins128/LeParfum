using LeParfum.Application.Models;

namespace LeParfum.Infrastructure.Security.Cryptography
{
    public class BCryptAlgorithm
    {
        public string HasPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool Verify(string password, User user)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
    }
}