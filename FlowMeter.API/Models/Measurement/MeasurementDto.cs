using FlowMeter.API.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Measurement
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

        public static double GetCurrentFlow(CreateMeasurementDto createMeasurement, double radius)
        {
            var sectionArea = GetSectionArea(createMeasurement, radius);

            return sectionArea * createMeasurement.Velocity;
        }

        private static double GetSectionArea(CreateMeasurementDto createMeasurement, double radius)
        {
            return 2.00;
        }

        public static bool CheckIsSpecialPoint(double currentFlow, double averageFlow)
        {
            return currentFlow > 2 * averageFlow;
        }
    }
}
