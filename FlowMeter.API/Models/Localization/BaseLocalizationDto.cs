using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Localization
{
    public class BaseLocalizationDto
    {
        public string Name { get; set; }
        public decimal GpsCoordinate1 { get; set; }
        public decimal GpsCoordinate2 { get; set; }
        public double CanalRadius { get; set; }
    }
}
