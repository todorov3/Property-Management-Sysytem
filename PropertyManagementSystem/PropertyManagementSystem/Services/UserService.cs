using AutoMapper;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<User> CreateUser(UserCreateDto userDto)
        {
            var newUser = _mapper.Map<User>(userDto);
            return await _userRepository.CreateUser(newUser);
        }

        public async Task<User> UpdateUser(int id, UserUpdateDto user)
        {
            //var userToUpdate = _mapper.Map<User>(user);
            //userToUpdate.Id = id;

            //var updatedUser = await _userRepository.UpdateUser(id, userToUpdate);
            //return updatedUser;

            var userToUpdate = _mapper.Map <UserUpdateDto>(GetUserById(id));
            var updatedUser = await _userRepository.UpdateUser(id, _mapper.Map<User>(userToUpdate));
            return updatedUser;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            //var userDtos = _mapper.Map<List<UserDto>>(users);
            //return userDtos;
            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            //var userDto = _mapper.Map<UserDto>(user);
            //return userDto;
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            //var userDto = _mapper.Map<UserDto>(user);
            //return userDto;
            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            //var userDto = _mapper.Map<UserDto>(user);
            //return userDto;
            return user;
        }
    }
}
