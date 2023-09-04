using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Repositories.Contracts
{
    public interface IPropertyRepository
    {
        Task<Property> GetPropertyById(int id);
        Task<List<Property>> GetPropertyByLandlordId(int id);
        Task<List<Property>> GetAllProperties();
        Task<Property> CreateProperty(Property property);
        Task<Property> UpdateProperty(Property property);
        Task<Property> DeleteProperty(int id);
    }
}
