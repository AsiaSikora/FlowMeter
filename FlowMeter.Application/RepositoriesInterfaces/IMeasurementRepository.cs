using FlowMeter.Domain;
using System.Collections.Generic;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface IMeasurementRepository : IGenericRepository<Measurement>
    {
        public List<Measurement> GetMeasurementsForSurvey(int surveyId);
        public Survey GetMeasurementSurvey(int surveyId);
        public double GetAverageFlow(int surveyId);
    }
}
