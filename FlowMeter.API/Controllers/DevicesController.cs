using FlowMeter.Application.DTOs.Device;
using FlowMeter.Application.Services.Devices;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetDevices(int userId)
        {
            var devices = _service.GetDevices(userId);

            return Ok(devices);
        }

        [HttpGet("{id}", Name = "GetDevice")]
        public IActionResult GetDevice(int id)
        {
            var device = _service.GetDevice(id);

            return Ok(device);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateDevice(int id, [FromBody] UpdateDeviceDto updateDeviceDto)
        {
            _service.UpdateDevice(id, updateDeviceDto);

            return NoContent();
        }

        [HttpPost]

        public IActionResult CreateDevice([FromBody] CreateDeviceDto createDevice, int userId)
        {
            var deviceDto = _service.CreateDevice(createDevice, userId);

            return CreatedAtRoute("Get", new { id = deviceDto.Id }, deviceDto);
        }

    }
}