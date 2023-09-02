using PropertyManagementSystem.Models;
using PropertyManagementSystem.Repositories.Contracts;

namespace PropertyManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
