using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeter.Domain
{
    public class Device
    {
        public int Id { get; set; }
        public int DeviceNumber { get; set; }
        public User User { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}