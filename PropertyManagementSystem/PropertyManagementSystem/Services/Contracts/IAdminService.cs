using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface IAdminService
    {
        Task<User> BlockUser(int id, User user);
        Task<User> UnblockUser(int id, User user);
        Task<User> PromoteUserToAdmin(int id, User user);
        Task<User> DemoteAdminToUser(int id, User user);
    }
}
