using FlowMeter.Domain;
using System.Collections.Generic;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        public Survey GetSurveyWithLocalization(int id);
        public List<Survey> GetSurveysWithLocalizationDeviceMeasurements(int userId);
        public List<Survey> GetLastFiveSurveys(int userId);
        public List<Survey> GetAllSurveysWithoutMeasurements(int userId);
        public Survey GetSurveyWithIncludes(int surveyId);
        public Survey GetLastSurvey(int userId);
    }
}
