using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FlowMeter.API.Models.Survey;
using FlowMeter.Domain;

namespace FlowMeter.API.Models.Device
{
    public class DeviceDto : BaseDeviceDto
    {
        [Required]
        public int Id { get; set; }
        public List<SurveyDto> Surveys { get; set; }
    }
}