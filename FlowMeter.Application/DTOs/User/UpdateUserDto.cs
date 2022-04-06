using FlowMeter.Application.DTOs.Device;
using System.Collections.Generic;

namespace FlowMeter.Application.DTOs.User
{
    public class UpdateUserDto : BaseUserDto
    {
        public List<DeviceDto> Devices { get; set; }
    }
}
