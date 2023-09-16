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

        public Task<Property> CreateProperty(PropertyCreateDto property)
        {
            throw new NotImplementedException();
        }

        public Task<Property> UpdateProperty(PropertyUpdateDto property)
        {
            throw new NotImplementedException();
        }

        public Task<Property> DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Property> GetProperty(int id)
        {
            var property = await _propertyRepository.GetPropertyById(id);
            CheckIsPropertyExists(id);
            return property;
        }

        public Task<Property> AcceptRequest(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Property> DeclineRequest(int id)
        {
            throw new NotImplementedException();
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
