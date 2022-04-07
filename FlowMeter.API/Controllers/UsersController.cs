using FlowMeter.Application.DTOs.User;
using FlowMeter.Application.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetUsers()
        {
            var usersDto = await _service.GetUsers();

            return Ok(usersDto);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userDto = await _service.GetUser(id);

            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            await _service.UpdateUser(id, updateUserDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _service.DeleteUser(id);

            return NoContent();
        }

    }
}
