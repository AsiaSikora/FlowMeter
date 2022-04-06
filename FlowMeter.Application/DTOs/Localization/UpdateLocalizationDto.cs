using FlowMeter.Application.DTOs.Survey;
using System.Collections.Generic;

namespace FlowMeter.Application.DTOs.Localization
{
    public class UpdateLocalizationDto : BaseLocalizationDto
    {
        public List<SurveyDto> Surveys { get; set; }
    }
}
