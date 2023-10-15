using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
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

        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] FeedbackCreateDto feedbackCreateDto)
        {
            var newFeedback = await _feedbackService.CreateFeedback(feedbackCreateDto);
            return CreatedAtRoute("GetFeedbackById", new { id = newFeedback.Id }, newFeedback);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            return Ok(await _feedbackService.GetAllFeedbacks());
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            return Ok(await _feedbackService.GetFeedbackById(id));
        }

        [HttpGet("byLandlordId/{landlordId}")]
        public async Task<IActionResult> GetAllFeedbacksAsLandlord(int landlordId)
        {
            return Ok(await _feedbackService.GetAllFeedbacksAsLandlord(landlordId));
        }

        [HttpGet("byTenandId/{tenandId}")]
        public async Task<IActionResult> GetAllFeedbacksAsTenand(int tenandId)
        {
            return Ok(await _feedbackService.GetAllFeedbacksAsTenand(tenandId));
        }

        [HttpGet("byUserId/{userId}")]
        public async Task<IActionResult> GetAllFeedbacksByUserId(int userId)
        {
            return Ok(await _feedbackService.GetAllFeedbacksByUserId(userId));
        }

        [HttpGet("ratingAs/{llId}")]
        public async Task<IActionResult> GetAverageRatingAsLandlord(int llId)
        {
            return Ok(await _feedbackService.GetAverageRatingAsLandlord(llId));
        }

        [HttpGet("rating/{tenandId}")]
        public async Task<IActionResult> GetAverageRatingAsTenand(int tenandId)
        {
            return Ok(await _feedbackService.GetAverageRatingAsTenand(tenandId));
        }
    }
}
