using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Data;
using FlowMeter.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation.Repositories
{
    public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public async Task<Survey> GetSurveyWithLocalization(int id)
        {
            return await _db
                .Include(x => x.Localization)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyCollection<Survey>> GetSurveysWithLocalizationDeviceMeasurements(int userId)
        {
            return await _db
                .Include(x => x.Localization)
                .Include(x => x.Device)
                .Include(x => x.Measurements)
                .Where(x => x.Device.UserId == userId)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<Survey>> GetLastFiveSurveys(int userId)
        {
            return await _db
                .Include(x => x.Localization)
                .Include(x => x.Device)
                .Where(x => x.Device.UserId == userId)
                .OrderByDescending(x => x.Date)
                .Take(5)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<Survey>> GetAllSurveysWithoutMeasurements(int userId)
        {
            return await _db
                .Include(x => x.Localization)
                .Include(x => x.Device)
                .Where(x => x.Device.UserId == userId)
                .OrderBy(x => x.Date)
                .ToListAsync();
        }

        public async Task<Survey> GetSurveyWithIncludes(int surveyId)
        {
            return await _db
                .Include(x => x.Device)
                .Include(x => x.Localization)
                .Include(x => x.Measurements)
                .FirstOrDefaultAsync(x => x.Id == surveyId);
        }

        public async Task<Survey> GetLastSurvey(int userId)
        {
            return await _db
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync(x => x.Device.UserId == userId);
        }
    }
}
