using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlowMeter.API.Models.Device;
using FlowMeter.API.Models.Localization;
using Newtonsoft.Json;

namespace FlowMeter.API.Models.User
{
    public class UserDto : BaseUserDto 
    {
        [Required]
        public int Id { get; set; }
        [JsonIgnore] 
        public string Hash { get; set; }
        public List<DeviceDto> Devices { get; set; }
        public List<LocalizationDto> Localizations { get; set; }
        
    }
}
