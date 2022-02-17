using FlowMeter.API.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Measurement
{
    public class BaseMeasurementDto
    {
        public string Battery { get; set; }
        public double Pressure { get; set; }
        public double Temperature { get; set; }
    }
}
