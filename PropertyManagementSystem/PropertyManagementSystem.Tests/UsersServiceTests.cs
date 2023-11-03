using AutoMapper;
using Moq;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Tests
{
    [TestClass]
    public class UsersServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private IUserService _userService;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        }

        //[TestMethod]
        //public async void ReturnCorrectUserById()
        //{
        //    int userId = 1;
        //    User expectedUser = new User 
        //    { 
        //        Id = userId, 
        //        FirstName = "First", 
        //        LastName = "Last", 
        //        Username = "Username", 
        //        Email = "email@Mail.com", 
        //        PhoneNumber = "0000000000", 
        //        UserPassword = "123"
        //    };

        //    _userRepositoryMock.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(expectedUser);

        //    var result = await _userService.GetUserById(userId);

        //    Assert.AreEqual(expectedUser.Id, result.Id);
        //}

        [TestMethod]
        public async Task GetUserById_WhenValidId_ReturnsUser()
        {
            var id = 1;

            User expectedUser = new User
            {
                Id = id,
                Username = "Username",
                Email = "email@Mail.com",
            };

            var userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object);

            _userRepositoryMock.Setup(repo => repo.GetUserById(id)).ReturnsAsync(expectedUser);


            var result = await userService.GetUserById(id);

            //Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Id, result.Id);
        }

        [TestMethod]
        public async Task GetUserByEmail_WhenValidEmail_ReturnsUser()
        {
            var email = "testmail@mail.com";

            User expectedUser = new User
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last",
                Username = "Username",
                Email = email,
                PhoneNumber = "0000000000",
                UserPassword = "123"
            };

            _userRepositoryMock.Setup(repo => repo.GetUserByEmail(email)).ReturnsAsync(expectedUser);

            var result = await _userService.GetUserByEmail(email);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Email, result.Email);
        }

        [TestMethod]
        public async Task TestCreateUser()
        {
            var newUser = new UserCreateDto()
            {
                Username = "Test",
                Email = "testmail@test.com",
                UserPassword = "123"
            };

            var expectedUser = new User
            {
                Username = newUser.Username,
                Email = newUser.Email,
                UserPassword = newUser.UserPassword
            };

            _userRepositoryMock.Setup(repo => repo.CreateUser(It.IsAny<User>())).ReturnsAsync(expectedUser);

            var result = _userService.CreateUser(newUser);

            var userResult = await result;

            Assert.AreEqual(expectedUser.Username, userResult.Username);
        }
    }
}