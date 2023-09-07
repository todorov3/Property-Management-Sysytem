using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Repositories.Contracts
{
    public interface IPropertyRepository
    {
        Task<Property> GetPropertyById(int id);
        Task<List<Property>> GetPropertyByLandlordId(int id);
        Task<List<Property>> GetAllProperties();
        Task<Property> CreateProperty(PropertyCreateDto property);
        Task<Property> UpdateProperty(int id, PropertyUpdateDto property);
        Task<Property> DeleteProperty(int id);
        Task<Property> ArchiveProperty(int id);
    }
}
