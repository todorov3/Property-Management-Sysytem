using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IUserService _userService;
        public PropertyService()
        {
            
        }

        public Task<Property> GetPropertyById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Property> GetPropertyByLandlordId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Property>> GetAllProperties()
        {
            var properties = await _propertyRepository.GetAllProperties();
            foreach (var property in properties)
            {
                
            }
        }

        public Task<Property> CreateProperty(PropertyCreateDto property)
        {
            throw new NotImplementedException();
        }

        public Task<Property> UpdateProperty(PropertyUpdateDto property)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public Task ArchiveProperty(int id)
        {
            throw new NotImplementedException();
        }
    }
}
