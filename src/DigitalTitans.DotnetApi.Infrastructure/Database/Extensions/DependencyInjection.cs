using System;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using DigitalTitans.DotnetApi.Infrastructure.Database.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalTitans.DotnetApi.Infrastructure.Database.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}

