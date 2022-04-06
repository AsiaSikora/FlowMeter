using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        List<Device> GetAllDevicesWithUsersAndSurveys(Expression<Func<Device, bool>> expression = null,
            Func<IQueryable<Device>, IOrderedQueryable<Device>> orderBy = null);

        List<Device> GetAllDevicesWithIncludes(int userId);
    }
}
