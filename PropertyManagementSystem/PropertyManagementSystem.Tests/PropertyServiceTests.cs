using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class PropertyServiceTests
    {
        private Mock<IPropertyRepository> _propertyRepositoryMock;
        private IPropertyService _propertyService;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void Setup()
        {
            _propertyRepositoryMock = new Mock<IPropertyRepository>();
            _mapperMock = new Mock<IMapper>();
            _propertyService = new PropertyService(_propertyRepositoryMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task TestGetPropertyById_WhenIdIsValid()
        {
            var id = 1;

            Property expectedProperty = new Property
            {
                Id = id,
                LandlordId = 2,
                Price = 200
            };

            var propertyService = new PropertyService(_propertyRepositoryMock.Object, _mapperMock.Object);

            _propertyRepositoryMock.Setup(repo => repo.GetPropertyById(id)).ReturnsAsync(expectedProperty);

            var result = await propertyService.GetPropertyById(id);

            Assert.AreEqual(expectedProperty.Id, result.Id);
        }

        [TestMethod]
        public async Task TestGetAll()
        {
            var expectedProperties = new List<Property>
            {
                new Property
                {
                    Id = 1,
                    LandlordId = 2,
                    Price = 200
                },

                new Property
                {
                    Id = 2,
                    LandlordId = 3,
                    Price = 200
                }
            };

            _propertyRepositoryMock.Setup(repo => repo.GetAllProperties()).ReturnsAsync(expectedProperties);

            var result = await _propertyService.GetAllProperties();

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(expectedProperties, result);
        }

        [TestMethod]
        public async Task GetPropertiesByLandlordId_WhenIdIsValid()
        {
            var landlordId = 2;
            var expectedProperties = new List<Property>
            {
                new Property
                {
                    Id = 1,
                    LandlordId = landlordId,
                    Price = 200
                },

                new Property
                {
                    Id = 2,
                    LandlordId = landlordId,
                    Price = 200
                }
            };

            _propertyRepositoryMock.Setup(repo => repo.GetPropertyByLandlordId(landlordId)).ReturnsAsync(expectedProperties);

            var result = await _propertyService.GetPropertyByLandlordId(landlordId);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(expectedProperties, result);
        }

        [TestMethod]
        public async Task CreateNewProperty_WhenParamsAreValid()
        {
            var landlordId = 2;
            var newProperty = new PropertyCreateDto()
            {
                LandlordId = landlordId,
                Price = 200
            };

            var expectedProperty = new Property
            {
                LandlordId = newProperty.LandlordId,
                Price = newProperty.Price
            };

            _propertyRepositoryMock.Setup(repo => repo.CreateProperty(It.IsAny<PropertyCreateDto>())).ReturnsAsync(expectedProperty);

            var result = await _propertyService.CreateProperty(newProperty);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedProperty, result);
        }
    }
}
