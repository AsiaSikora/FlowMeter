using System.Collections.Generic;
using FlowMeter.API.Models.Survey;
using FlowMeter.Domain;

namespace FlowMeter.API.Models.Device
{
    public class UpdateDeviceDto : BaseDeviceDto
    {
        public List<SurveyDto> Surveys { get; set; }
    }
}