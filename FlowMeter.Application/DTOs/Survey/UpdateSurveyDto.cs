using FlowMeter.Application.DTOs.Measurement;
using System.Collections.Generic;

namespace FlowMeter.Application.DTOs.Survey
{
    public class UpdateSurveyDto : BaseSurveyDto
    {
        public List<MeasurementDto> Measurements { get; set; }
    }
}
