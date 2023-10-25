using System;
using DotnetApi.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetApi.Infrastructure.Services.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeOffsetProvider, DateTimeOffsetProvider>();
            services.AddTransient<IUserProvider, UserProvider>();
            services.AddSingleton<IClaimProvider, ClaimProvider>();

            return services;
        }
    }
}

