using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeter.Domain
{
    public class Measurement
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Battery { get; set; }
        public double Pressure { get; set; }
        public double Temperature { get; set; }
        public double CurrentFlow { get; set; }
        public double AverageFlow { get; set; }
        public bool IsSpecialPoint { get; set; }
        public Survey Survey { get; set; }
        [ForeignKey(nameof(Survey))]
        public int SurveyId { get; set; }
    }
}