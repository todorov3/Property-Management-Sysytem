using AutoMapper;
using Moq;
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
    }
}
