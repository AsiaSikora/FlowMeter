using FlowMeter.Domain;
using System.Collections.Generic;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface ILocalizationRepository : IGenericRepository<Localization>
    {
        public List<Localization> GetLocalizationsForUser(int userId);

    }
}
