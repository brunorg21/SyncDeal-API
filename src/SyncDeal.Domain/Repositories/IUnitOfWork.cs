namespace SyncDeal.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
