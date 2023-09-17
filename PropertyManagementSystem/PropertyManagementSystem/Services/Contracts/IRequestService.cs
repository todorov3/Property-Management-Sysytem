using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface IRequestService
    {
        Task<Request> CreateRequest();
        Task DeleteRequest();
    }
}
