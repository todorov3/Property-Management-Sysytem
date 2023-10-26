using AutoMapper;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public RequestService(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<Request> CreateRequest(RequestCreateDto request)
        {
            var newRequest = _mapper.Map<Request>(request);
            return await _requestRepository.CreateRequest(newRequest);
        }

        public async Task DeleteRequest(int id)
        {
            await _requestRepository.DeleteRequest(id);
        }

        public async Task<Request> GetRequestById(int id)
        {
            return await _requestRepository.GetRequestById(id);
        }

        public async Task<List<Request>> GetRequestsByTenandId(int id)
        {
            return await _requestRepository.GetRequestsByTenandId(id);
        }

        public async Task<List<Request>> GetRequestsByPropertyId(int propertyId)
        {
            return await _requestRepository.GetRequestsByPropertyId(propertyId);
        }

        public async Task AcceptRequest(int id)
        {
            await _requestRepository.AcceptRequest(id);
        }

        public async Task DeclineRequest(int id)
        {
            await _requestRepository.DeclineRequest(id);
        }
    }
}
