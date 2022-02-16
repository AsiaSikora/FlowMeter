using FlowMeter.API.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Localization
{
    public class LocalizationDto
    {
        public int Id { get; set; }
        public List<SurveyDto> Surveys { get; set; }
    }
}
