using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Localization
{
    public class BaseLocalizationDto
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal GpsCoordinate1 { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal GpsCoordinate2 { get; set; }
        public double CanalRadius { get; set; }
    }
}
