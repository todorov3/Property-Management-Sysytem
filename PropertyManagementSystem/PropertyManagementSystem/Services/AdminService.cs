using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services.Contracts;
using AutoMapper;
using PropertyManagementSystem.Exceptions;

namespace PropertyManagementSystem.Services
{
    public class AdminService : IAdminService
    {
        private const string CanNotBlockUser = "You are not Admin";

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AdminService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }
        public async Task<User> BlockUser(int id, User user)
        {
            if (user.IsAdmin)
            {
                var userToBlock = await _userRepository.GetUserById(id);
                userToBlock.IsActive = false;
                //var updateUser = _mapper.Map<UserUpdateDto>(userToBlock);
                return await _userRepository.UpdateUser(id, updateUser);
            }
            throw new UnauthorizedOperationException(CanNotBlockUser);
        }

        public Task<User> DemoteAdminToUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> PromoteUserToAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UnblockUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
