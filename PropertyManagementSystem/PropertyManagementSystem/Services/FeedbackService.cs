using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public async Task<Feedback> CreateFeedback(FeedbackCreateDto feedback)
        {
            return await _feedbackRepository.CreateFeedback(feedback);
        }

        public async Task<Feedback> UpdateFeedback(int id, FeedbackUpdateDto feedback)
        {
            return await _feedbackRepository.UpdateFeedback(id, feedback);
        }
    }
}
