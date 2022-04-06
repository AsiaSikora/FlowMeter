using FlowMeter.Application.DTOs.Device;
using FlowMeter.Application.DTOs.Localization;
using FlowMeter.Application.DTOs.Measurement;
using System;
using System.Collections.Generic;

namespace FlowMeter.Application.DTOs.Survey
{
    public class SurveyDto : BaseSurveyDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public LocalizationDto Localization { get; set; }
        public DeviceDto Device { get; set; }
        public List<MeasurementDto> Measurements { get; set; }
    }
}
