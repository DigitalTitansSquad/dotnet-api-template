using System;
using DotnetApi.Core.Common.Interfaces;
using DotnetApi.Infrastructure.Database.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetApi.Infrastructure.Database.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDbContext<DotnetApiDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDotnetApiDbContext>(provider => provider.GetRequiredService<DotnetApiDbContext>());

            return services;
        }
    }
}

