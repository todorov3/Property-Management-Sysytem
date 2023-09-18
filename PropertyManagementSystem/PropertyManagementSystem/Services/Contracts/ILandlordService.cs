using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface ILandlordService
    {
        Task<Property> CreateProperty(PropertyCreateDto property);
        Task<Property> UpdateProperty(int id, PropertyUpdateDto property);
        Task DeleteProperty(int id);
        Task<Property> GetProperty(int id);
        Task<List<Property>> GetAllProperties();
        Task AcceptRequest(int id);
        Task DeclineRequest(int id);
    }
}
