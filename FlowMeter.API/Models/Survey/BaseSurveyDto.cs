using FlowMeter.API.Models.Device;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Survey
{
    public class BaseSurveyDto
    {
        public DateTime Date { get; set; }
        public DeviceDto Device { get; set; }
        public int DeviceId { get; set; }
        //public string Name { get; set; }
        //public decimal? GpsCoordinate1 { get; set; }
        //public decimal? GpsCoordinate2 { get; set; }
        //public double CanalRadius { get; set; }
    }
}
