using FlowMeter.Data;
using FlowMeter.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation.Repositories
{
    public class MeasurementRepository : GenericRepository<Measurement>
    {
        public MeasurementRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public List<Measurement> GetAllMeasurementsWithSurveys()
        {
            return _db.Include(x => x.Survey).ToList();
        }
    }
}
