using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class TenandService : ITenandService
    {
        private readonly IRequestService _requestService;
        private readonly IFeedbackService _feedbackService;

        public TenandService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<Feedback> CreateFeedback(FeedbackCreateDto feedback)
        {
            return await _feedbackService.CreateFeedback(feedback);
        }

        public async Task<Request> CreateRequest(RequestCreateDto requestDto)
        {
            return await _requestService.CreateRequest(requestDto);
        }

        public async Task DeleteRequest(int id)
        {
            await _requestService.DeleteRequest(id);
        }
    }
}
