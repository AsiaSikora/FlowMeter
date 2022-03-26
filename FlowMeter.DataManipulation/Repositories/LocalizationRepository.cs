using FlowMeter.Data;
using FlowMeter.Domain;
using System.Collections.Generic;
using System.Linq;
using FlowMeter.DataManipulationInterfaces;

namespace FlowMeter.DataManipulation.Repositories
{
    public class LocalizationRepository : GenericRepository<Localization>, ILocalizationRepository
    {
        public LocalizationRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public List<Localization> GetLocalizationsForUser(int userId)
        {
            return _db
                //.Include(x => x.Surveys)
                .Where(x => x.UserId == userId)
                .ToList();
        }

    }
}
