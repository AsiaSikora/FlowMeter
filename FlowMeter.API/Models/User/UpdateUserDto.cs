using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.User
{
    public class UpdateUserDto : BaseUserDto
    {
        public List<Device> Devices { get; set; }
    }
}
