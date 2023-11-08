using AutoMapper;
using Moq;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services;
using PropertyManagementSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.Tests
{
    [TestClass]
    public class FeedbackServiceTests
    {
        private Mock<IFeedbackRepository> _feedbackRepositoryMock;
        private IFeedbackService _feedbackService;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void Setup()
        {
            _feedbackRepositoryMock = new Mock<IFeedbackRepository>();
            _mapperMock = new Mock<IMapper>();
            _feedbackService = new FeedbackService(_feedbackRepositoryMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task CreateFeedback_WhenParamsAreValid()
        {
            var newFeedback = new FeedbackCreateDto()
            {
                Content = "Content",
                AuthorId = 2,
                CommentedUserId = 3
            };

            var expectedFeedback = new Feedback()
            {
                Content = newFeedback.Content,
                AuthorId = newFeedback.AuthorId,
                CommentedUserId = newFeedback.CommentedUserId
            };

            _feedbackRepositoryMock.Setup(repo => repo.CreateFeedback(It.IsAny<Feedback>())).ReturnsAsync(expectedFeedback);

            var result = await _feedbackService.CreateFeedback(newFeedback);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedFeedback.Content, result.Content);
        }

        [TestMethod]
        public async Task TestGetAll()
        {
            var allFeedbacks = new List<Feedback>()
            {
                new Feedback()
                {
                    Content = "Content1",
                    AuthorId = 2,
                    CommentedUserId = 3
                },

                new Feedback()
                {
                    Content = "Content2",
                    AuthorId = 1,
                    CommentedUserId = 5
                }
            };

            _feedbackRepositoryMock.Setup(repo => repo.GetAllFeedbacks()).ReturnsAsync(allFeedbacks);

            var result = await _feedbackService.GetAllFeedbacks();

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(allFeedbacks, result);
        }
    }
}
