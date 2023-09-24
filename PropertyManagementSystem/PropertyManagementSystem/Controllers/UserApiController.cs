using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserApiController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            return Ok(await _userService.GetUserByUsername(username));
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            return Ok(await _userService.GetUserByEmail(email));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreate)
        {
            var newUser = await _userService.CreateUser(userCreate);
            return CreatedAtRoute("GetUserById", new { id = newUser.Id }, newUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userUpdate)
        {
            var userToUpdate = _mapper.Map<User>(userUpdate);
            var updatedUser = await _userService.UpdateUser(id, userToUpdate);

            return Ok(_mapper.Map<UserUpdateDto>(updatedUser));
        }
    }
}
