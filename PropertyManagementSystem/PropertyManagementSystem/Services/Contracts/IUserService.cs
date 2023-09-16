using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmail(string email);
        Task<User> GetAllUsers();
        Task<User> CreateUser(UserCreateDto user);
        Task<User> UpdateUser(UserUpdateDto user);
        Task DeleteUser(int id);
    }
}
