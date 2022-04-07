using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Data;
using FlowMeter.DataManipulation.Repositories;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlowMeterDbContext _context;

        public UnitOfWork(FlowMeterDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => new UserRepository(_context);
        public IDeviceRepository Devices => new DeviceRepository(_context);
        public IMeasurementRepository Measurements => new MeasurementRepository(_context);
        public ISurveyRepository Surveys => new SurveyRepository(_context);
        public ILocalizationRepository Localizations => new LocalizationRepository(_context);
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
