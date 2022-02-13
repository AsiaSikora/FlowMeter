namespace FlowMeter.Domain
{
    public class Result
    {
        public int Id { get; set; }
        public Measurement Measurement { get; set; }
        public decimal Flow { get; set; }
        public bool IsSpecialPoint { get; set; } = false;
    }
}