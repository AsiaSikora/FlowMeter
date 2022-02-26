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
        public List<MeasurementDto> Measurements { get; set; }
    }
}
