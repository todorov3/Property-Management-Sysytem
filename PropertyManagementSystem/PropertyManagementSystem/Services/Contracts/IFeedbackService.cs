﻿using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Services.Contracts
{
    public interface IFeedbackService
    {
        Task<Feedback> CreateFeedback(FeedbackCreateDto feedback);
    }
}
