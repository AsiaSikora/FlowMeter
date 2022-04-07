using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Data;
using FlowMeter.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsersWithDevicesAndLocalizations(Expression<Func<User, bool>> expression = null,
            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null)
        {
            return await base.GetAll(expression, orderBy, new List<string>() { "Devices", "Localizations" });
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
