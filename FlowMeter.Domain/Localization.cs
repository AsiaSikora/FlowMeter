using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace FlowMeter.Domain
{
    public class Localization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Tuple<decimal, decimal> GPS { get; set; }
        public string Decimal { get; set; }
        public List<Measurement> ListOfMeasurements { get; set; }
    }
}