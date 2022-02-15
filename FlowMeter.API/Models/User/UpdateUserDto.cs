using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowMeter.API.Models.Device;

namespace FlowMeter.API.Models.User
{
    public class UpdateUserDto : BaseUserDto
    {
        public List<DeviceDto> Devices { get; set; }
    }
}
