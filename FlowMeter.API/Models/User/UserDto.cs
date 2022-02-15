using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.User
{
    public class UserDto : BaseUserDto 
    {
        [Required]
        public int Id { get; set; }
        public string Hash { get; set; }
        public List<Device> Devices { get; set; }
    }
}
