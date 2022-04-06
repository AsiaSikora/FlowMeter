using FlowMeter.Application.DTOs.Device;
using FlowMeter.Application.DTOs.Localization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowMeter.Application.DTOs.User
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
