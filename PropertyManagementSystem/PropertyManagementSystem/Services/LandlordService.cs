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

        public async Task<Property> GetProperty(int id)
        {
            return await _propertyRepository.GetPropertyById(id);
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

    }
}
