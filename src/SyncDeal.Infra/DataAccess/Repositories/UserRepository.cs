using SyncDeal.Domain.Entities;
using SyncDeal.Domain.Repositories;

namespace SyncDeal.Infra.DataAccess.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly SyncDealDbContext _dbContext;

        public UserRepository(SyncDealDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Add(User user)
        {
            var result = await _dbContext.Users.AddAsync(user);
            return result.Entity;
        }
    }
}
