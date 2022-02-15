using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FlowMeter.Domain;

namespace FlowMeter.DataManipulation.Repositories
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        List<Device> GetAllDevicesWithUsersAndSurveys(Expression<Func<Device, bool>> expression = null, 
            Func<IQueryable<Device>, IOrderedQueryable<Device>> orderBy = null);
    }
}