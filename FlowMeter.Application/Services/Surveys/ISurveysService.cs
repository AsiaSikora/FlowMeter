using FlowMeter.Application.DTOs.Survey;
using FlowMeter.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMeter.Application.Services.Surveys
{
    public interface ISurveysService
    {
        Task<Survey> CreateSurvey(CreateSurveyDto createSurvey);
        Task DeleteSurvey(int id);
        Task<IReadOnlyCollection<SurveyDto>> GetAllSurveysWithoutMeasurements(int userId);
        Task<IReadOnlyCollection<SurveyDto>> GetLastFiveSurveys(int userId);
        Task<SurveyDto> GetLastSurvey(int userId);
        Task<SurveyDto> GetSurvey(int id);
        Task<IReadOnlyCollection<SurveyDto>> GetSurveys(int userId);
        Task UpdateSurvey(int id, UpdateSurveyDto updateSurveyDto);
    }
}