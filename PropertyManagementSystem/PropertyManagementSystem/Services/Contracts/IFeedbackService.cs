using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface IFeedbackService
    {
        Task<Feedback> CreateFeedback(FeedbackCreateDto feedback);
        Task<Feedback> UpdateFeedback(int id, FeedbackUpdateDto feedback);
        Task<Feedback> GetFeedbackById(int id);
        Task<List<Feedback>> GetAllFeedbacks();
        Task<List<Feedback>> GetAllFeedbacksAsLandlord(int userId);
        Task<List<Feedback>> GetAllFeedbacksAsTenand(int userId);
        Task<List<Feedback>> GetAllFeedbacksByUserId(int userId);
        Task<double> GetAverageRatingAsLandlord(int userId);
        Task<double> GetAverageRatingAsTenand(int userId);
    }
}
