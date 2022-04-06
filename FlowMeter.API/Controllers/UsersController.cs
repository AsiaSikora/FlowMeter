using FlowMeter.Application.DTOs.User;
using FlowMeter.Application.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace FlowMeter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var usersDto = _service.GetUsers();

            return Ok(usersDto);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetUser(int id)
        {
            var userDto = _service.GetUser(id);

            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            _service.UpdateUser(id, updateUserDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _service.DeleteUser(id);

            return NoContent();
        }

    }
}
