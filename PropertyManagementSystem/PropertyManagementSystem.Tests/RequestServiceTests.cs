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
    public class RequestServiceTests
    {
        private Mock<IRequestRepository> _requestRepositoryMock;
        private IRequestService _requestService;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void Setup()
        {
            _requestRepositoryMock = new Mock<IRequestRepository>();
            _mapperMock = new Mock<IMapper>();
            _requestService = new RequestService(_requestRepositoryMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task CreateRequest_WhenParamsAreValid()
        {
            var request = new RequestCreateDto()
            {
                TenandId = 5,
                PropertyId = 2,
            };

            var expectedRequest = new Request()
            {
                TenandId = request.TenandId,
                PropertyId = request.PropertyId
            };

            _requestRepositoryMock.Setup(repo => repo.CreateRequest(It.IsAny<Request>())).ReturnsAsync(expectedRequest);

            var result = await _requestService.CreateRequest(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRequest.TenandId, result.TenandId);
        }

        [TestMethod]
        public async Task GetRequestById()
        {
            var id = 1;
            var expectedRequest = new Request
            {
                Id = id,
                TenandId = 5,
                PropertyId = 2
            };

            var requestService = new RequestService(_requestRepositoryMock.Object, _mapperMock.Object);

            _requestRepositoryMock.Setup(repo => repo.GetRequestById(id)).ReturnsAsync(expectedRequest);

            var result = await requestService.GetRequestById(id);

            Assert.AreEqual(expectedRequest.Id, result.Id);
        }

        [TestMethod]
        public async Task GetRequestByTenandId_WhenIdIsValid()
        {
            var tId = 5;
            var expectedRequest = new List<Request>
            {
                new Request
                {
                    TenandId = tId,
                    PropertyId = 2
                }
            };

            var requestService = new RequestService(_requestRepositoryMock.Object, _mapperMock.Object);

            _requestRepositoryMock.Setup(repo => repo.GetRequestsByTenandId(tId)).ReturnsAsync(expectedRequest);

            var result = await requestService.GetRequestsByTenandId(tId);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(expectedRequest, result);
        }

        [TestMethod]
        public async Task GetRequestByPropertyId_WhenIdIsValid()
        {
            var pId = 2;
            var expectedRequest = new List<Request>
            {
                new Request
                {
                    TenandId = 5,
                    PropertyId = pId
                }
            };

            var requestService = new RequestService(_requestRepositoryMock.Object, _mapperMock.Object);

            _requestRepositoryMock.Setup(repo => repo.GetRequestsByPropertyId(pId)).ReturnsAsync(expectedRequest);

            var result = await _requestService.GetRequestsByPropertyId(pId);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(expectedRequest, result);
        }
    }
}
