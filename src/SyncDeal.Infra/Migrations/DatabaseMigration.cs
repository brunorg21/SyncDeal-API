using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SyncDeal.Infra.DataAccess;

namespace SyncDeal.Infra.Migrations
{
    public static class DatabaseMigration
    {
        public static async Task MigrateDatabaseAsync(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<SyncDealDbContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}
