using SyncDeal.Domain.Entities;

namespace SyncDeal.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
    }
}
