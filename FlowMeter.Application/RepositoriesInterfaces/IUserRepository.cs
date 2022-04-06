using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetAllUsersWithDevicesAndLocalizations(Expression<Func<User, bool>> expression = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null);
        User GetByEmail(string email);
        User GetById(int id);
    }
}
