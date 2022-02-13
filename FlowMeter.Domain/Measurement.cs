using System;

namespace FlowMeter.Domain
{
    public class Measurement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Localization { get; set; }
        public string Device { get; set; }
        public decimal Velocity { get; set; }
        public string Distance { get; set; }
        public string Battery { get; set; }
        public string Pressure { get; set; }
        public decimal Temperature { get; set; }
    }
}