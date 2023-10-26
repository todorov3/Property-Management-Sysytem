using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Repositories.Contracts
{
    public interface IRequestRepository
    {
        Task<Request> CreateRequest(Request requestDto);
        Task DeleteRequest(int id);
        Task<Request> GetRequestById(int id);
        Task<List<Request>> GetRequestsByTenandId(int id);
        Task<List<Request>> GetRequestsByPropertyId(int propertyId);
        Task AcceptRequest(int id);
        Task DeclineRequest(int id);
    }
}
