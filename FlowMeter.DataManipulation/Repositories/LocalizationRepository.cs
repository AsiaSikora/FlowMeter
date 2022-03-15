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
    public class LocalizationRepository : GenericRepository<Localization>
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
