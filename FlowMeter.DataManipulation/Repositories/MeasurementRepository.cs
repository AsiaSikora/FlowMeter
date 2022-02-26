using FlowMeter.Data;
using FlowMeter.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation.Repositories
{
    public class MeasurementRepository : GenericRepository<Measurement>
    {
        public MeasurementRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public List<Measurement> GetMeasurementsForSurvey(int surveyId)
        {
            return _db
                .Where(x => x.SurveyId == surveyId)
                .ToList();
        }

        public Survey GetMeasurementSurvey(int surveyId)
        {
            return _context
                .Surveys
                .Include(x => x.Localization)
                .FirstOrDefault(x => x.Id == surveyId);
        }

        public double GetAverageFlow(int surveyId)
        {
            return _db
                .Where(x => x.SurveyId == surveyId)
                .Average(x => x.CurrentFlow);
        }


    }
}
