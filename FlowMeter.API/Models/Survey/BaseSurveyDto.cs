using FlowMeter.API.Models.Device;
using FlowMeter.API.Models.Localization;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Survey
{
    public class BaseSurveyDto
    {
        public int DeviceId { get; set; }
        public int LocalizationId { get; set; }
    }
}
