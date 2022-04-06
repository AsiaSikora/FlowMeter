namespace FlowMeter.Application.DTOs.Measurement
{
    public class CreateMeasurementDto : BaseMeasurementDto
    {
        public double Dimension { get; set; }
        public double Velocity { get; set; }
    }
}
