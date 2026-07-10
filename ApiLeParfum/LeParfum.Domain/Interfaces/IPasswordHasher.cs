namespace LeParfum.Domain.Interfaces
{
    public interface IPasswordHasher 
    {
        Task<string> HashPasswordAsync(string password);
        Task<bool> VerifyPasswordAsync(string password, string hash);
    }
}