using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface ITenandService
    {
        Task<Request> CreateRequest(RequestCreateDto requestDto);
        Task DeleteRequest(int id);
        Task<Feedback> CreateFeedback(FeedbackCreateDto feedback);
    }
}
