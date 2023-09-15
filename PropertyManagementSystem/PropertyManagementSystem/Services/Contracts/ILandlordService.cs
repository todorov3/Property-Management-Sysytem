using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface ILandlordService
    {
        Task<Property> CreateProperty(PropertyCreateDto property);
        Task<Property> UpdateProperty(PropertyUpdateDto property);
        Task<Property> DeleteProperty(int id);
        Task<Property> GetProperty(int id);
        Task<Property> AcceptRequest(int id);
        Task<Property> DeclineRequest(int id);
    }
}
