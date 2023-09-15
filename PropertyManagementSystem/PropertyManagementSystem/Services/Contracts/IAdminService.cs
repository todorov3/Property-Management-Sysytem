using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface IAdminService
    {
        Task<User> BlockUser(int id);
        Task<User> UnblockUser(int id);
        Task<User> PromoteUserToAdmin(int id);
        Task<User> DemoteAdminToUser(int id);
    }
}
