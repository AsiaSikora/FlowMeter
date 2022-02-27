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
    public class SurveyRepository : GenericRepository<Survey>
    {
        public SurveyRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public Survey GetSurveyWithLocalization(int id)
        {
            return _db
                .Include(x => x.Localization)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Survey> GetSurveysWithLocalizationDeviceMeasurements(int userId)
        {
            return _db
                .Include(x => x.Localization)
                .Include(x => x.Device)
                .Include(x => x.Measurements)
                .Where(x => x.Device.UserId == userId)
                .ToList();
        }

        public List<Survey> GetLastFiveSurveys(int userId)
        {
            return _db
                .Include(x => x.Localization)
                .Include(x => x.Device)
                .Where(x => x.Device.UserId == userId)
                .OrderByDescending(x => x.Date)
                .ToList();
        }
    }
}
