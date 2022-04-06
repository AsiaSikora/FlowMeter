using FlowMeter.Application.DTOs.Survey;
using FlowMeter.Domain;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Surveys
{
    public interface ISurveysService
    {
        Survey CreateSurvey(CreateSurveyDto createSurvey);
        void DeleteSurvey(int id);
        List<SurveyDto> GetAllSurveysWithoutMeasurements(int userId);
        List<SurveyDto> GetLastFiveSurveys(int userId);
        SurveyDto GetLastSurvey(int userId);
        SurveyDto GetSurvey(int id);
        List<SurveyDto> GetSurveys(int userId);
        void UpdateSurvey(int id, UpdateSurveyDto updateSurveyDto);
    }
}
