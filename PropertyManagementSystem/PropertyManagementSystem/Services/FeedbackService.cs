using AutoMapper;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }
        public async Task<Feedback> CreateFeedback(FeedbackCreateDto feedbackDto)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDto);
            return await _feedbackRepository.CreateFeedback(feedback);
        }

        public async Task<List<Feedback>> GetAllFeedbacksByUserId(int userId)
        {
            var feedbacks = await _feedbackRepository.GetAllFeedbacksByUserId(userId);
            //var feedbackDtos = _mapper.Map<List<FeedbackResponseDto>>(feedbacks);
            return feedbacks;
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            var feedback = await _feedbackRepository.GetFeedbackById(id);
            //var feedbackDto = _mapper.Map<FeedbackResponseDto>(feedback);
            return feedback;
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            var feedbacks = await _feedbackRepository.GetAllFeedbacks();
            var feedbackDtos = _mapper.Map<List<FeedbackResponseDto>>(feedbacks);
            return feedbacks;
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsLandlord(int userId)
        {
            var feedbacks = await _feedbackRepository.GetAllFeedbacksAsLandlord(userId);
            //var feedbackDtos = _mapper.Map<List<FeedbackResponseDto>>(feedbacks);
            return feedbacks;
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsTenand(int userId)
        {
            var feedbacks = await _feedbackRepository.GetAllFeedbacksAsTenand(userId);
           // var feedbackDtos = _mapper.Map<List<FeedbackResponseDto>>(feedbacks);
            return feedbacks;
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
