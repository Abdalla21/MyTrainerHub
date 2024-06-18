using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTrainerHub.Core.Domain.Entities;
using MyTrainerHub.Core.Helpers;
using MyTrainerHub.Infrastructure.DatabaseContext;

namespace MyTrainerHub.UI.ServicesInjectionExtension
{
    public static class DBServicesInjection
    {
        public static IServiceCollection AddDBContextService(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddDbContext<ApplicationDBContext>(
                options => options.UseSqlServer(
                    config.GetConnectionString(DBConstants.ConnectionStringName))
                , ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddApiEndpoints();

            return services;
        }
    }
}
