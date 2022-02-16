using FlowMeter.API.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Measurement
{
    public class BaseMeasurementDto
    {
        public DateTime Time { get; set; }
        public string Battery { get; set; }
        public double? Pressure { get; set; }
        public double? Temperature { get; set; }
        public double? CurrentFlow { get; set; }
        public double? AverageFlow { get; set; }
        public double? MedianFlow { get; set; }
        public bool IsSpecialPoint { get; set; }
        public SurveyDto Survey { get; set; }
        public int SurveyId { get; set; }
    }
}
