using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Data;
using FlowMeter.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation.Repositories
{
    public class MeasurementRepository : GenericRepository<Measurement>, IMeasurementRepository
    {
        public MeasurementRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Measurement>> GetMeasurementsForSurvey(int surveyId)
        {
            return await _db
                .Where(x => x.SurveyId == surveyId)
                .ToListAsync();
        }

        public async Task<Survey> GetMeasurementSurvey(int surveyId)
        {
            return await _context
                .Surveys
                .Include(x => x.Localization)
                .FirstOrDefaultAsync(x => x.Id == surveyId);
        }

        public async Task<double> GetAverageFlow(int surveyId)
        {
            var listOfMeasurements = await _db.Where(x => x.SurveyId == surveyId).ToListAsync();
            
            if (listOfMeasurements.Count() > 0)
            {
                return listOfMeasurements
                .Average(x => x.CurrentFlow);
            }

            return 0;
        }


    }
}
