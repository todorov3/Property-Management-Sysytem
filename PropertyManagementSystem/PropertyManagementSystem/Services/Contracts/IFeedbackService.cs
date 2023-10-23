using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface IFeedbackService
    {
        Task<Feedback> CreateFeedback(FeedbackCreateDto feedback);
        Task<FeedbackResponseDto> GetFeedbackById(int id);
        Task<List<FeedbackResponseDto>> GetAllFeedbacks();
        Task<List<FeedbackResponseDto>> GetAllFeedbacksAsLandlord(int userId);
        Task<List<FeedbackResponseDto>> GetAllFeedbacksAsTenand(int userId);
        Task<List<FeedbackResponseDto>> GetAllFeedbacksByUserId(int userId);
        Task<double> GetAverageRatingAsLandlord(int userId);
        Task<double> GetAverageRatingAsTenand(int userId);
    }
}
