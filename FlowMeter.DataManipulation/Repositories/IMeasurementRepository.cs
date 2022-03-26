﻿using System.Collections.Generic;
using FlowMeter.Domain;

namespace FlowMeter.DataManipulation.Repositories
{
    public interface IMeasurementRepository : IGenericRepository<Measurement>
    {
        public List<Measurement> GetMeasurementsForSurvey(int surveyId);
        public Survey GetMeasurementSurvey(int surveyId);
        public double GetAverageFlow(int surveyId);
    }
}