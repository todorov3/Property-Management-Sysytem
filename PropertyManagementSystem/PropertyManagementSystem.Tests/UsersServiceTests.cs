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
        public async Task TestGetUserByUsername()
        {
            var username = "username";

            var expectedUser = new User
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last",
                Username = username,
                Email = "testmail@mail.com",
                PhoneNumber = "0000000000",
                UserPassword = "123"
            };

            _userRepositoryMock.Setup(repo => repo.GetUserByUsername(username)).ReturnsAsync(expectedUser);

            var result = await _userService.GetUserByUsername(username);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Username, result.Username);
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

            Assert.IsNotNull(userResult);
            Assert.AreEqual(expectedUser.Username, userResult.Username);
        }

        [TestMethod]
        public async Task TestUserUpdate()
        {
            int id = 1;
            var newUser = new UserUpdateDto()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Username = "TestUsername",
                Email = "test@email.com"
            };

            var user = new User()
            {
                Id = id,
                FirstName = "OldFirstName",
                LastName = "OldLastName",
                Username = "OldUsername",
                Email = "old@email.com"
            };

            _userRepositoryMock.Setup(repo => repo.GetUserById(id)).ReturnsAsync(user);

            var updatedUser = new User()
            {
                Id = id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Username = newUser.Username,
                Email = newUser.Email
            };

            _userRepositoryMock.Setup(repo => repo.UpdateUser(id, It.IsAny<User>())).ReturnsAsync(updatedUser);

            var result = await _userService.UpdateUser(id, newUser);

            Assert.IsNotNull(result);
            Assert.AreEqual(updatedUser.FirstName, result.FirstName);
            Assert.AreEqual(updatedUser.LastName, result.LastName);
            Assert.AreEqual(updatedUser.Username, result.Username);
            Assert.AreEqual(updatedUser.Email, result.Email);
        }

        [TestMethod]
        public async Task TestGetAllUsers()
        {
            var expectedUsers = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "TestUser1",
                    LastName = "TestUser1Family",
                    Username = "TestUsername1",
                    Email = "email1@email.com"
                },

                new User
                {
                    Id = 2,
                    FirstName = "TestUser2",
                    LastName = "TestUser2Family",
                    Username = "TestUsername2",
                    Email = "email2@email.com"
                }
            };

            var userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object);

            _userRepositoryMock.Setup(repo => repo.GetAllUsers()).ReturnsAsync(expectedUsers);

            var result = await _userService.GetAllUsers();

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(expectedUsers, result);
        }
    }
}