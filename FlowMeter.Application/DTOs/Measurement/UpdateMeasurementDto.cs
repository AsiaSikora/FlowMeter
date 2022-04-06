namespace FlowMeter.Application.DTOs.Measurement
{
    public class UpdateMeasurementDto : BaseMeasurementDto
    {
        public double CurrentFlow { get; set; }
        public double AverageFlow { get; set; }
        public bool IsSpecialPoint { get; set; }
    }
}
