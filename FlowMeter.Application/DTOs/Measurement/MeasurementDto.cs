using FlowMeter.Application.DTOs.Survey;
using System;

namespace FlowMeter.Application.DTOs.Measurement
{
    public class MeasurementDto : BaseMeasurementDto
    {
        public int Id { get; set; }
        public double CurrentFlow { get; set; }
        public double AverageFlow { get; set; }
        public bool IsSpecialPoint { get; set; }
        public SurveyDto Survey { get; set; }
        public int SurveyId { get; set; }
        public DateTime Time { get; set; }

    }
}
