using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SyncDeal.Domain.Repositories;
using SyncDeal.Infra.DataAccess;
using SyncDeal.Infra.DataAccess.Repositories;

namespace SyncDeal.Infra
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        public static void AddRepositories(IServiceCollection services)

        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("Connection");

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 42));
            services.AddDbContext<SyncDealDbContext>(config => config.UseMySql(connection, serverVersion));
        }
    }
}
