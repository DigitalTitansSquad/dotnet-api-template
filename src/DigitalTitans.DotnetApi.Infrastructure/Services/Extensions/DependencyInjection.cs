using System;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalTitans.DotnetApi.Infrastructure.Services.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IUserProvider, UserProvider>();
            services.AddSingleton<IClaimProvider, ClaimProvider>();

            return services;
        }
    }
}

