using Dapper;
using System.Data;
using PropertyManagementSystem.Data;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;

        public UserRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<User> GetUserById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<User>(
                                                                    "spUserGetById", 
                                                                    connection, 
                                                                    commandType: 
                                                                    CommandType.StoredProcedure);
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Username", username);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<User>(
                                                                    "spUserGetByUsername", 
                                                                    connection, 
                                                                    commandType: 
                                                                    CommandType.StoredProcedure);
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Email", email);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<User>(
                                                                    "spUserGetByEmail", 
                                                                    connection, 
                                                                    commandType: 
                                                                    CommandType.StoredProcedure);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            using var connection = _dapperContext.CreateConnection();
            {
                return (await connection.QueryAsync<User>(
                                                        "spUsersGetAll", 
                                                        commandType: 
                                                        CommandType.StoredProcedure))
                                                        .ToList();
            }
        }

        public async Task<User> CreateUser(UserCreateDto userDto)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("FirstName", userDto.FirstName, DbType.String);
            parameters.Add("LastName", userDto.LastName, DbType.String);
            parameters.Add("Username", userDto.Username, DbType.String);
            parameters.Add("Email", userDto.Email, DbType.String);
            parameters.Add("PhoneNumber", userDto.PhoneNumber, DbType.String);
            parameters.Add("UserPassword", userDto.UserPassword, DbType.String);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync(
                                             "spUserCreate", 
                                             parameters, 
                                             commandType: 
                                             CommandType.StoredProcedure);
                return GetUserByUsername(userDto.Username).Result;
            }
        }

        public async Task<User> UpdateUser(int id, UserUpdateDto userDto)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("FirstName", userDto.FirstName, DbType.String);
            parameters.Add("LastName", userDto.LastName, DbType.String);
            parameters.Add("Username", userDto.Username, DbType.String);
            parameters.Add("Email", userDto.Email, DbType.String);
            parameters.Add("PhoneNumber", userDto.PhoneNumber, DbType.String);
            parameters.Add("UserPassword", userDto.UserPassword, DbType.String);
            parameters.Add("IsActive", userDto.IsActive, DbType.Boolean);
            parameters.Add("IsAdmin", userDto.IsAdmin, DbType.Boolean);
            parameters.Add("IsDeleted", userDto.IsDeleted, DbType.Boolean);
            parameters.Add("UserPhoto", userDto.UserPhoto, DbType.String);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync("spUserUpdate", 
                                                    parameters, 
                                                    commandType: 
                                                    CommandType.StoredProcedure);
                return GetUserById(id).Result;
            }
        }

        public async Task<User> DeleteUser(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<User>("spUserDelete", 
                                                                            parameters, 
                                                                            commandType: 
                                                                            CommandType.StoredProcedure);
            }
        }
    }
}
