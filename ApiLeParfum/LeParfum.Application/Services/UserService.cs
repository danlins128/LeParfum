using LeParfum.Domain.Entities;
using LeParfum.Domain.Exceptions;
using LeParfum.Domain.Interfaces;
using LeParfum.Application.Interfaces;

namespace LeParfum.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        
        public async Task<UserEntity?> DeleteUserAsync(Guid userId)
        {
            var userExists = await _userRepository.GetUserByIdAsync
            (userId);
            if (userExists == null)
            {
                throw new UserNotFoundException("Usuário não encontrado.");
            }
            return await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<UserEntity?> LoginUserAsync(UserEntity user)
        {
            var loginCredentials = await _userRepository.GetUsernameAsync(user.UserName);
            if (loginCredentials == null)
            {
                throw new UserNotFoundException("Usuário não encontrado.");
            }

            var passwordValid = await _passwordHasher.VerifyPasswordAsync(user.Password, loginCredentials.Password);

            if (passwordValid == false)
            {
                throw new UserPasswordIncorrectException("Usuário ou senha incorretos.");
            }

            return loginCredentials;
        }

        public async Task<UserEntity?> RegisterUserAsync(UserEntity user)
        {
            var userExists = await _userRepository.GetUsernameAsync(user.UserName);
            if (userExists != null)
            {
                throw new UserAlreadyException("Usuário já cadastrado. Tente fazer login.");
            }
            
            var passwordHashed = await _passwordHasher.HashPasswordAsync(user.Password);

            user.Password = passwordHashed;
            var newUser = await _userRepository.AddUserAsync(user);
            return newUser;
        }
    }
}