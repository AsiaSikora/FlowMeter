using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FlowMeter.Application.RepositoriesInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        T Get(Expression<Func<T, bool>> expression = null, List<string> includes = null);
        List<T> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null);
        void Modify(T entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<T> entities);
    }
}
