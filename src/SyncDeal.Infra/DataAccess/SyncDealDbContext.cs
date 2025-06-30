using Microsoft.EntityFrameworkCore;
using SyncDeal.Domain.Entities;

namespace SyncDeal.Infra.DataAccess
{
    public class SyncDealDbContext : DbContext
    {
        public SyncDealDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
