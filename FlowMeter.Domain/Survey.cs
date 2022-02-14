using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(Device))]
        public int DeviceId { get; set; }
        public Localization Localization { get; set; }
        [ForeignKey(nameof(Localization))]
        public int LocalizationId { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}
