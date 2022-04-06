using FlowMeter.Application.DTOs.Survey;
using FlowMeter.Application.DTOs.User;
using System.Collections.Generic;

namespace FlowMeter.Application.DTOs.Device
{
    public class DeviceDto : BaseDeviceDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public int UserId { get; set; }
        public List<SurveyDto> Surveys { get; set; }
    }
}
