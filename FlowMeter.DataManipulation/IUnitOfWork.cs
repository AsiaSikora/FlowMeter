using FlowMeter.DataManipulation.Repositories;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FlowMeter.DataManipulation
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IDeviceRepository Devices { get; }
        void Save();

    }
}