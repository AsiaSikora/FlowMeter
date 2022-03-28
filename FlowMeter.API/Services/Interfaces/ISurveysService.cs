using FlowMeter.API.Models.Survey;
using FlowMeter.Domain;
using System.Collections.Generic;

namespace FlowMeter.API.Services.Interfaces
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