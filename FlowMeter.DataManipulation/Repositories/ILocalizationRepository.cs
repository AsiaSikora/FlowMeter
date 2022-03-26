using System.Collections.Generic;
using FlowMeter.Domain;

namespace FlowMeter.DataManipulation.Repositories
{
    public interface ILocalizationRepository : IGenericRepository<Localization>
    {
        public List<Localization> GetLocalizationsForUser(int userId);

    }
}