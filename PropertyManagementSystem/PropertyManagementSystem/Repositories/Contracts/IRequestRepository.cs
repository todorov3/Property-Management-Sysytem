using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Repositories.Contracts
{
    public interface IRequestRepository
    {
        Task<Request> CreateRequest(RequestCreateDto requestDto);
        Task DeleteRequest(int id);
        Task<Request> GetRequestById(int id);
        Task<List<Request>> GetRequestByTenandId(int id);
        Task<List<Request>> GetRequestsByPropertyId(int propertyId);
        Task AcceptRequest(int id);
        Task DeclineRequest(int id);
    }
}
