using SyncDeal.Domain.Repositories;

namespace SyncDeal.Infra.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SyncDealDbContext _dbContext;
        public UnitOfWork(SyncDealDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
