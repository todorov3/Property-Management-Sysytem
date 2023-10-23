using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Repositories.Contracts
{
    public interface IFeedbackRepository
    {
        Task<Feedback> CreateFeedback(Feedback feedback);
        Task<Feedback> GetFeedbackById(int id);
        Task<List<Feedback>> GetAllFeedbacks();
        Task<List<Feedback>> GetAllFeedbacksAsLandlord(int userId);
        Task<List<Feedback>> GetAllFeedbacksAsTenand(int userId);
        Task<List<Feedback>> GetAllFeedbacksByUserId(int userId);
        Task<double> GetAverageRatingAsLandlord(int userId);
        Task<double> GetAverageRatingAsTenand(int userId);
    }
}
