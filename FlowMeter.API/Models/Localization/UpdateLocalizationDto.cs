using FlowMeter.API.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Models.Localization
{
    public class UpdateLocalizationDto : BaseLocalizationDto
    {
        public List<SurveyDto> Surveys { get; set; }
    }
}
