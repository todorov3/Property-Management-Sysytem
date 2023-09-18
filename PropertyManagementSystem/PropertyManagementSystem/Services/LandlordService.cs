using PropertyManagementSystem.Exceptions;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class LandlordService : ILandlordService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IRequestRepository _requestRepository;

        public LandlordService(IPropertyRepository propertyRepository, IRequestRepository requestRepository)
        {
            _propertyRepository = propertyRepository;
            _requestRepository = requestRepository;
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

        public async Task<Property> GetProperty(int id)
        {
            var property = await _propertyRepository.GetPropertyById(id);
            _ = CheckIsPropertyExists(id);
            return property;
        }

        public async Task AcceptRequest(int id)
        {
            await _requestRepository.AcceptRequest(id);
        }

        public async Task DeclineRequest(int id)
        {
            await _requestRepository.DeclineRequest(id);
        }

        public Task<List<Property>> GetAllProperties()
        {
            return _propertyRepository.GetAllProperties();
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
