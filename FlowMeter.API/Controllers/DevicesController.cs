using System.Collections.Generic;
using AutoMapper;
using FlowMeter.API.Models.Device;
using FlowMeter.API.Models.User;
using FlowMeter.DataManipulation;
using Microsoft.AspNetCore.Mvc;

namespace FlowMeter.API.Controllers
{
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DevicesController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetDevices(int userId)
        {
            var devices = _uow.Devices.GetAllDevicesWithIncludes(userId);
            var devicesDto = _mapper.Map<List<DeviceDto>>(devices);
            return Ok(devicesDto);
        }

        [HttpGet("{id}", Name = "GetDevice")]
        public IActionResult GetDevice(int id)
        {
            var device = _uow.Devices.Get(x => x.Id == id);
            var deviceDto = _mapper.Map<DeviceDto>(device);
        
            return Ok(deviceDto);
        }
        
        [HttpPut("{id:int}")]
        public IActionResult UpdateDevice(int id, [FromBody]UpdateDeviceDto updateDeviceDto)
        {
            var device = _uow.Devices.Get(x => x.Id == id);

            if (device == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDeviceDto, device);
            _uow.Devices.Modify(device);
            _uow.Save();

            return NoContent();
        }
        
    }
}