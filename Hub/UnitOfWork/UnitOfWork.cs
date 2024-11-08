using Hub.Data;
using Hub.Repository;
using Hub.Repository.IRepository;

namespace Hub.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Company = new CompanyRepository(_dbContext);
        }
        public ICompanyRepository Company { get; set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }
    }
}
