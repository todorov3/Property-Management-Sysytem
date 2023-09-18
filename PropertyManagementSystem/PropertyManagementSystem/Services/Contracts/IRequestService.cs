using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface IRequestService
    {
        Task<Request> CreateRequest(RequestCreateDto request);
        Task DeleteRequest(int id);
        Task<Request> GetRequestById(int id);
        Task<List<Request>> GetRequestsByTenandId(int id);
        Task<List<Request>> GetRequestsByPropertyId(int propertyId);
        Task AcceptRequest(int id);
        Task DeclineRequest(int id);
    }
}
