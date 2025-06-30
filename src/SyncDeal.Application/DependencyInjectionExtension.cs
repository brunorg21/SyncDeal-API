using Microsoft.Extensions.DependencyInjection;
using SyncDeal.Application.AutoMapper;
using SyncDeal.Application.UseCases.User.Create;
using SyncDeal.Application.UseCases.User.Register;

namespace SyncDeal.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUseCase, RegisterUserUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }
    }
}
