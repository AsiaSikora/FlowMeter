using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace FlowMeter.Domain
{
    public class Localization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? GpsCoordinate1 { get; set; }
        public decimal? GpsCoordinate2 { get; set; }
        public double CanalRadius { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}