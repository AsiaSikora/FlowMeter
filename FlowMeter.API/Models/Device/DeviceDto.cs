using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FlowMeter.API.Models.Survey;
using FlowMeter.API.Models.User;
using FlowMeter.Domain;

namespace FlowMeter.API.Models.Device
{
    public class DeviceDto : BaseDeviceDto
    {
        
        public int Id { get; set; }
        public UserDto User { get; set; }
        public int UserId { get; set; }
        public List<SurveyDto> Surveys { get; set; }
    }
}