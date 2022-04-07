using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Data;
using FlowMeter.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlowMeter.DataManipulation.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(FlowMeterDbContext context) : base(context)
        {
            
        }

        public async Task<IReadOnlyCollection<Device>> GetAllDevicesWithUsersAndSurveys(Expression<Func<Device, bool>> expression = null, 
            Func<IQueryable<Device>, IOrderedQueryable<Device>> orderBy = null)
        {
            return await base.GetAll(expression, orderBy, new List<string>() { "User" });
        }

        public async Task<IReadOnlyCollection<Device>> GetAllDevicesWithIncludes(int userId)
        {
            return await _db
                .Include(x => x.Surveys)
                .Include(x => x.User)
                .Where(x => x.User.Id == userId)
                .ToListAsync();
        }

    }
}