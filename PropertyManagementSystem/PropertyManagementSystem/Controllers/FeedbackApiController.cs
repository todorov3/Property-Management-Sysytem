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


    }
}
