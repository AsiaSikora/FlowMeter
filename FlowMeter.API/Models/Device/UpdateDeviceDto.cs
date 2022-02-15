using System.Collections.Generic;
using FlowMeter.Domain;

namespace FlowMeter.API.Models.Device
{
    public class UpdateDeviceDto : BaseDeviceDto
    {
        public List<Survey> Surveys { get; set; }
    }
}