using PropertyManagementSystem.Exceptions;
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

        public async Task<Property> GetPropertyById(int id)
        {
            var property = await _propertyRepository.GetPropertyById(id);
            _ = CheckIsPropertyExists(id);
            return property;
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

        public async Task<Property> UpdateProperty(int id, Property property)
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

        private async Task<Property> CheckIsPropertyExists(int id)
        {
            var property = await _propertyRepository.GetPropertyById(id);
            if (property.IsDeleted == true || property.IsArchived == true || property == null)
            {
                throw new EntityNotFoundException("Property doesn't exists.");
            }
            return property;
        }
    }
}
