using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackService(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        public Task<Feedback> CreateFeedback(FeedbackCreateDto feedback)
        {
            return _feedbackService.CreateFeedback(feedback);
        }

        public Task<Feedback> UpdateFeedback(FeedbackUpdateDto feedback)
        {
            return _feedbackService.UpdateFeedback(feedback);
        }
    }
}
