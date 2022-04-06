using FlowMeter.Application.DTOs.Survey;
using System.Collections.Generic;

namespace FlowMeter.Application.DTOs.Device
{
    public class UpdateDeviceDto : BaseDeviceDto
    {
        public List<SurveyDto> Surveys { get; set; }
    }
}
