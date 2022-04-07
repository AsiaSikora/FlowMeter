using FlowMeter.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface ILocalizationRepository : IGenericRepository<Localization>
    {
        Task<IReadOnlyCollection<Localization>> GetLocalizationsForUser(int userId);

    }
}
