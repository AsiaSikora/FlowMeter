using FlowMeter.Application.DTOs.Device;
using FlowMeter.Application.Services.Devices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowMeter.API.Controllers
{
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesService _service;

        public DevicesController(IDevicesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevices(int userId)
        {
            var devices = await _service.GetDevices(userId);

            return Ok(devices);
        }

        [HttpGet("{id}", Name = "GetDevice")]
        public async Task<IActionResult> GetDevice(int id)
        {
            var device = await _service.GetDevice(id);

            return Ok(device);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDevice(int id, [FromBody] UpdateDeviceDto updateDeviceDto)
        {
            await _service.UpdateDevice(id, updateDeviceDto);

            return NoContent();
        }

        [HttpPost]

        public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceDto createDevice, int userId)
        {
            var deviceDto = await _service.CreateDevice(createDevice, userId);

            return CreatedAtRoute("Get", new { id = deviceDto.Id }, deviceDto);
        }

    }
}