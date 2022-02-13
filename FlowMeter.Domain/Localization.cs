using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace FlowMeter.Domain
{
    public class Localization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GpsCoordinate1 { get; set; }
        public decimal GpsCoordinate2 { get; set; }
        public Shape Shape { get; set; }
        public int ShapeId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}