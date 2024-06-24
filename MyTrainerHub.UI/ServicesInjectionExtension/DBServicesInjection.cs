using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTrainerHub.Core.Domain.Entities;
using MyTrainerHub.Core.Helpers;
using MyTrainerHub.Infrastructure.DatabaseContext;

namespace MyTrainerHub.UI.ServicesInjectionExtension
{
    public static class DbServicesInjection
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddDbContext<ApplicationDBContext>(
                options => options.UseSqlServer(
                    config.GetConnectionString(DbConstants.ConnectionStringName))
                , ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders()
                .AddApiEndpoints();

            return services;
        }
    }
}
