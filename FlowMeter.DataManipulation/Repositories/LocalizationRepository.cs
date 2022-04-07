using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Data;
using FlowMeter.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation.Repositories
{
    public class LocalizationRepository : GenericRepository<Localization>, ILocalizationRepository
    {
        public LocalizationRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Localization>> GetLocalizationsForUser(int userId)
        {
            return await _db
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

    }
}
