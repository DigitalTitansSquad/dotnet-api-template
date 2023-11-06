using System;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalTitans.DotnetApi.Infrastructure.FluentValidation.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddValidators(this IServiceCollection services, params Assembly[] assemblies)
        {
            return services.AddValidatorsFromAssemblies(assemblies);
        }
    }
}

