using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IDeviceRepository Devices { get; }
        IMeasurementRepository Measurements { get; }
        ISurveyRepository Surveys { get; }
        ILocalizationRepository Localizations { get; }
        Task Save();
    }
}
