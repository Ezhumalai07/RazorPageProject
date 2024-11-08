using Hub.Repository.IRepository;

namespace Hub.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Company { get; }
        void save();
    }
}
