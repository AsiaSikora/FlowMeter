using System.Collections.Generic;
using FlowMeter.Domain;

namespace FlowMeter.DataManipulationInterfaces
{
    public interface ILocalizationRepository : IGenericRepository<Localization>
    {
        public List<Localization> GetLocalizationsForUser(int userId);

    }
}