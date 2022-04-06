﻿using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Data;
using FlowMeter.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlowMeter.DataManipulation.Repositories
{
    public class MeasurementRepository : GenericRepository<Measurement>, IMeasurementRepository
    {
        public MeasurementRepository(FlowMeterDbContext context) : base(context)
        {
        }

        public List<Measurement> GetMeasurementsForSurvey(int surveyId)
        {
            return _db
                .Where(x => x.SurveyId == surveyId)
                .ToList();
        }

        public Survey GetMeasurementSurvey(int surveyId)
        {
            return _context
                .Surveys
                .Include(x => x.Localization)
                .FirstOrDefault(x => x.Id == surveyId);
        }

        public double GetAverageFlow(int surveyId)
        {
            var listOfMeasurements = _db.Where(x => x.SurveyId == surveyId).ToList();
            if (listOfMeasurements.Count() > 0)
            {
                return listOfMeasurements
                .Average(x => x.CurrentFlow);
            }

            return 0;

        }


    }
}
