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

        public async Task<List<Feedback>> GetAllFeedbacksByUserId(int userId)
        {
            return await _feedbackRepository.GetAllFeedbacksByUserId(userId);
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            return await _feedbackRepository.GetFeedbackById(id);
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await _feedbackRepository.GetAllFeedbacks();
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsLandlord(int userId)
        {
            return await _feedbackRepository.GetAllFeedbacksAsLandlord(userId);
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsTenand(int userId)
        {
            return await _feedbackRepository.GetAllFeedbacksAsTenand(userId);
        }

        public async Task<double> GetAverageRatingAsLandlord(int userId)
        {
            return await _feedbackRepository.GetAverageRatingAsLandlord(userId);
        }

        public async Task<double> GetAverageRatingAsTenand(int userId)
        {
            return await _feedbackRepository.GetAverageRatingAsTenand(userId);
        }
    }
}
