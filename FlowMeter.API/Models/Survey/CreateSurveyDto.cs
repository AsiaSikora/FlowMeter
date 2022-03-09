using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Survey
{
    public class CreateSurveyDto
    {
        public int DeviceNumber { get; set; }
        public string LocalizationName { get; set; }
    }
}
