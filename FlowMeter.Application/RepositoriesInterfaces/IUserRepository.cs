using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IReadOnlyCollection<User>> GetAllUsersWithDevicesAndLocalizations(Expression<Func<User, bool>> expression = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null);
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
    }
}
