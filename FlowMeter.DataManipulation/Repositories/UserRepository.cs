using FlowMeter.Data;
using FlowMeter.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public List<User> GetAllUsersWithDevices(Expression<Func<User, bool>> expression = null,
            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null)
        {
            return base.GetAll(expression, orderBy, new List<string>() { "Devices" });
        }


    }
}
