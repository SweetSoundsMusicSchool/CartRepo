namespace Capstone1.Models
{
    public class SweetRepository : ISweetRepository

    {
        private SweetDBContext _dbContext;
        public SweetRepository(SweetDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Service> GetAllService => _dbContext.Services;
    }
}
