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

        public MeasurementDto(CreateMeasurementDto createMeasurement, int surveyId, double radius, double averageFlow)
        {
            this.Battery = createMeasurement.Battery;
            this.Pressure = createMeasurement.Pressure;
            this.Temperature = createMeasurement.Temperature;
            this.Time = DateTime.Now;
            this.SurveyId = surveyId;
            this.CurrentFlow = GetCurrentFlow(createMeasurement, radius);
            this.AverageFlow = averageFlow;
            this.IsSpecialPoint = CheckIsSpecialPoint();
        }

        private double GetCurrentFlow(CreateMeasurementDto createMeasurement, double radius)
        {
            var sectionArea = GetSectionArea(createMeasurement, radius);

            return sectionArea * createMeasurement.Velocity;
        }

        private double GetSectionArea(CreateMeasurementDto createMeasurement, double radius)
        {
            return 2.00;
        }

        private bool CheckIsSpecialPoint()
        {
            if (this.CurrentFlow > 2 * this.AverageFlow)
            {
                return true;
            }

            return false;
        }
    }
}
