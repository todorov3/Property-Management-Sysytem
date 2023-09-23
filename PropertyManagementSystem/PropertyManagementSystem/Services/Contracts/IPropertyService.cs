using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface IPropertyService
    {
        Task<Property> GetPropertyById(int id);
        Task<List<Property>> GetPropertyByLandlordId(int id);
        Task<List<Property>> GetAllProperties();
        Task<Property> CreateProperty(PropertyCreateDto property);
        Task<Property> UpdateProperty(int id, Property property);
        Task DeleteProperty(int id);
        Task ArchiveProperty(int id);
    }
}
