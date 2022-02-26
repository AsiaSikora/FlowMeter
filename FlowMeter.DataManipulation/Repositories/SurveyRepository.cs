using FlowMeter.Data;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeter.DataManipulation.Repositories
{
    public class SurveyRepository : GenericRepository<Survey>
    {
        public SurveyRepository(FlowMeterDbContext context) : base(context)
        {
        }
    }
}
