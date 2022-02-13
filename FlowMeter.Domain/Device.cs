using System.Collections.Generic;

namespace FlowMeter.Domain
{
    public class Device
    {
        public int Id { get; set; }
        public int DeviceNumber { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}