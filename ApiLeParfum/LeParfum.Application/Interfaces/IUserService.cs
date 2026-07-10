using LeParfum.Domain.Entities;

namespace LeParfum.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity?> RegisterUserAsync(UserEntity user);
        Task<UserEntity?> LoginUserAsync(UserEntity user);
        Task<UserEntity?> DeleteUserAsync(Guid userId);
    }
}