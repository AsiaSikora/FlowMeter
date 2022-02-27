using FlowMeter.API.Models.Device;
using FlowMeter.API.Models.Localization;
using FlowMeter.API.Models.Measurement;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Survey
{
    public class SurveyDto : BaseSurveyDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public LocalizationDto Localization { get; set; }
        public DeviceDto Device { get; set; }
        public List<MeasurementDto> Measurements { get; set; }
        public double AverageFlow { get; set; }
    }
}
