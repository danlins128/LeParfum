using LeParfum.Domain.Entities;

namespace LeParfum.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetUsernameAsync(string userName);
        Task<UserEntity?> GetUserByIdAsync(Guid userId);
        Task<UserEntity?> AddUserAsync(UserEntity user);
        Task<UserEntity?> DeleteUserAsync(Guid userId);
    }
}