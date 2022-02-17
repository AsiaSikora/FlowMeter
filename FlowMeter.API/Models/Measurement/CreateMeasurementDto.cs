﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Measurement
{
    public class CreateMeasurementDto : BaseMeasurementDto
    {
        public double Dimension { get; set; }
        public double Velocity { get; set; }
    }
}
