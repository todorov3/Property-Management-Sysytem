using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public Task<Property> GetPropertyById(int id)
        {
            return _propertyRepository.GetPropertyById(id);
        }

        public Task<List<Property>> GetPropertyByLandlordId(int id)
        {
            return _propertyRepository.GetPropertyByLandlordId(id);
        }

        public async Task<List<Property>> GetAllProperties()
        {
            return await _propertyRepository.GetAllProperties();
        }

        public async Task<Property> CreateProperty(PropertyCreateDto property)
        {
            return await _propertyRepository.CreateProperty(property);
        }

        public async Task<Property> UpdateProperty(int id, PropertyUpdateDto property)
        {
            return await _propertyRepository.UpdateProperty(id, property);
        }

        public async Task DeleteProperty(int id)
        {
            await _propertyRepository.DeleteProperty(id);
        }

        public async Task ArchiveProperty(int id)
        {
            await _propertyRepository.ArchiveProperty(id);
        }
    }
}
