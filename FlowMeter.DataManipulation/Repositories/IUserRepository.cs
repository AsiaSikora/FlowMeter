using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FlowMeter.DataManipulation.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsersWithDevicesAndLocalizations(Expression<Func<User, bool>> expression = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null);
        void Add(User entity);
        void AddRange(IEnumerable<User> entities);
        User Get(Expression<Func<User, bool>> expression = null, List<string> includes = null);
        List<User> GetAll(Expression<Func<User, bool>> expression = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, List<string> includes = null);
        void Modify(User entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<User> entities);
        User GetByEmail(string email);
        User GetById(int id);
    }
}