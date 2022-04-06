using FlowMeter.Application.DTOs.Survey;
using System.Collections.Generic;

namespace FlowMeter.Application.DTOs.Localization
{
    public class LocalizationDto : BaseLocalizationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<SurveyDto> Surveys { get; set; }
    }
}
