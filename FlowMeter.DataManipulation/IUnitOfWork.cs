using FlowMeter.DataManipulation.Repositories;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FlowMeter.DataManipulationInterfaces;

namespace FlowMeter.DataManipulation
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IDeviceRepository Devices { get; }
        IMeasurementRepository Measurements { get; }
        ISurveyRepository Surveys { get; }
        ILocalizationRepository Localizations { get; }
        void Save();

    }
}