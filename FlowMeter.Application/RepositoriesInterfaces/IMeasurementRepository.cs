using FlowMeter.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface IMeasurementRepository : IGenericRepository<Measurement>
    {
        Task<IReadOnlyCollection<Measurement>> GetMeasurementsForSurvey(int surveyId);
        Task<Survey> GetMeasurementSurvey(int surveyId);
        Task<double> GetAverageFlow(int surveyId);
    }
}
