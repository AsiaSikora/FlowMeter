using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeter.Domain
{
    public class Survey
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Device Device { get; set; }
        public int DeviceId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Localization Localization { get; set; }
        public int LocalizationId { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}
