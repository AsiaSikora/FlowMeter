using FlowMeter.Data;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlowMeterDbContext _context;

        public UnitOfWork(FlowMeterDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<User> Users => new GenericRepository<User>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
