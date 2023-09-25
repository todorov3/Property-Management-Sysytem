using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/feedbacks")]
    public class FeedbackApiController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public FeedbackApiController(IFeedbackService feedbackService, IMapper maper)
        {
            _feedbackService = feedbackService;
            _mapper = maper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            return Ok(await _feedbackService.GetAllFeedbacks());
        }

        [HttpGet]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            return Ok(await _feedbackService.GetFeedbackById(id));
        }

        [HttpGet("{landlordId}")]
        public async Task<IActionResult> GetAllFeedbacksAsLandlord(int userId)
        {
            return Ok(await _feedbackService.GetAllFeedbacksAsLandlord(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacksAsTenand(int userId)
        {
            return Ok(await _feedbackService.GetAllFeedbacksAsTenand(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacksByUserId(int userId)
        {
            return Ok(await _feedbackService.GetAllFeedbacksByUserId(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAverageRatingAsLandlord(int userId)
        {
            return Ok(await _feedbackService.GetAverageRatingAsLandlord(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAverageRatingAsTenand(int userId)
        {
            return Ok(await _feedbackService.GetAverageRatingAsTenand(userId));
        }
    }
}
