using FlowMeter.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        Task<Survey> GetSurveyWithLocalization(int id);
        Task<IReadOnlyCollection<Survey>> GetSurveysWithLocalizationDeviceMeasurements(int userId);
        Task<IReadOnlyCollection<Survey>> GetLastFiveSurveys(int userId);
        Task<IReadOnlyCollection<Survey>> GetAllSurveysWithoutMeasurements(int userId);
        Task<Survey> GetSurveyWithIncludes(int surveyId);
        Task<Survey> GetLastSurvey(int userId);
    }
}
