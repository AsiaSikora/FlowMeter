using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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


        public List<Device> GetAllDevicesWithUsersAndSurveys(Expression<Func<Device, bool>> expression = null, 
            Func<IQueryable<Device>, IOrderedQueryable<Device>> orderBy = null)
        {
            return base.GetAll(expression, orderBy, new List<string>() { "User" });
        }

        public List<Device> GetAllDevicesWithIncludes(int userId)
        {
            return _db
                .Include(x => x.Surveys)
                .Include(x => x.User)
                .Where(x => x.User.Id == userId)
                .ToList();
        }
    }
}