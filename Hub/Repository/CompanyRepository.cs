using Hub.Data;
using Hub.Model;
using Hub.Repository.IRepository;

namespace Hub.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Company company)
        {
            var objFromDb = _dbContext.Companys.FirstOrDefault(x => x.Id == company.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = company.Name;
                objFromDb.Location = company.Location;
            }
        }
    }
}
