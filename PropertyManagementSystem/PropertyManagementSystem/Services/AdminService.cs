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
        private const string CanNotEditUserAccount = "You are not Admin";

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
                return await _userRepository.UpdateUser(id, userToBlock);
            }
            throw new UnauthorizedOperationException(CanNotEditUserAccount);
        }

        public async Task<User> UnblockUser(int id, User user)
        {
            if (user.IsAdmin)
            {
                var userToUnblock = await _userRepository.GetUserById(id);
                userToUnblock.IsActive = true;
                return await _userRepository.UpdateUser(id, userToUnblock);
            }
            throw new UnauthorizedOperationException(CanNotEditUserAccount);
        }

        public async Task<User> DemoteAdminToUser(int id, User user)
        {
            var adminToDemote = await _userRepository.GetUserById(id);
            if (user.Id == 1)
            {
                if (!adminToDemote.IsAdmin)
                {
                    throw new UnauthorizedOperationException(CanNotEditUserAccount);
                }
                if (!adminToDemote.IsActive)
                {
                    throw new UnauthorizedOperationException(CanNotEditUserAccount);
                }
                if (adminToDemote.IsDeleted)
                {
                    throw new UnauthorizedOperationException(CanNotEditUserAccount);
                }
            }
            adminToDemote.IsAdmin = false;
            return await _userRepository.UpdateUser(id, adminToDemote);
        }

        public async Task<User> PromoteUserToAdmin(int id, User user)
        {
            var userToPromote = await _userRepository.GetUserById(id);
            if (user.IsAdmin)
            {
                if (userToPromote.IsAdmin)
                {
                    throw new UnauthorizedOperationException(CanNotEditUserAccount);
                }
                if (!userToPromote.IsActive)
                {
                    throw new UnauthorizedOperationException(CanNotEditUserAccount);
                }
                if (userToPromote.IsDeleted)
                {
                    throw new UnauthorizedOperationException(CanNotEditUserAccount);
                }
            }
            userToPromote.IsAdmin = true;
            return await _userRepository.UpdateUser(id, userToPromote);
        }
    }
}
