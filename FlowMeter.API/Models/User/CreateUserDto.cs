using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.User
{
    public class CreateUserDto : BaseUserDto
    {
        [Required]

        public string Password { get; set; }
    }
}
