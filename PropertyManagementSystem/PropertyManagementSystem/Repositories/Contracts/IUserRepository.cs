using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllUsers();
        Task<User> CreateUser(UserCreateDto user);
        Task<User> UpdateUser(int id, UserUpdateDto user);
        Task DeleteUser(int id);
    }
}
