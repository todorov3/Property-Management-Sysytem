using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUser(UserCreateDto user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<User> UpdateUser(int id, UserUpdateDto user)
        {
            return await _userRepository.UpdateUser(id, user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public Task<User> GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public Task<User> GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
    }
}
