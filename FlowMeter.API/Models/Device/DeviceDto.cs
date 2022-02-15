using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FlowMeter.Domain;

namespace FlowMeter.API.Models.Device
{
    public class DeviceDto : BaseDeviceDto
    {
        [Required]
        public int Id { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}