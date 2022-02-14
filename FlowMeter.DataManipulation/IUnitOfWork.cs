using FlowMeter.Domain;

namespace FlowMeter.DataManipulation
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }

        void Save();
    }
}