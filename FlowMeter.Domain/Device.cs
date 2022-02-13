using System.Collections.Generic;

namespace FlowMeter.Domain
{
    public class Device
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public int DeviceNumber { get; set; }
        public List<Measurement> ListOfMeasurements { get; set; }
    }
}