using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null);
        Task<IReadOnlyCollection<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null);
        Task Modify(T entity);
        Task Remove(int id);
        Task RemoveRange(IEnumerable<T> entities);
    }
}
