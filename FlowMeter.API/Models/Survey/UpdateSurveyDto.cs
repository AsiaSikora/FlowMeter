using FlowMeter.API.Models.Measurement;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Survey
{
    public class UpdateSurveyDto : BaseSurveyDto
    {
        public List<MeasurementDto> Measurements { get; set; }
    }
}
