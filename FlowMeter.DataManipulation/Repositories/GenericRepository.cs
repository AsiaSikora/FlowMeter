using FlowMeter.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FlowMeter.DataManipulation.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FlowMeterDbContext _context;
        protected readonly DbSet<T> _db;

        public GenericRepository(FlowMeterDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.AsNoTracking().ToList();
        }

        public T Get(Expression<Func<T, bool>> expression = null,
            List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.AsNoTracking().FirstOrDefault(expression);
        }

        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _db.AddRange(entities);
        }

        public void Remove(int id)
        {
            var entity = _db.Find(id);
            _db.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Modify(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
