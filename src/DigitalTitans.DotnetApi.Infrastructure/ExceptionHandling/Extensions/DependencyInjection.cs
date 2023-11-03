using System;
using DigitalTitans.DotnetApi.Infrastructure.ExceptionHandling.Handlers;
using DigitalTitans.DotnetApi.Infrastructure.ExceptionHandling.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DigitalTitans.DotnetApi.Infrastructure.ExceptionHandling.Extensions;

public static class DependencyInjection
{
    public static void AddExceptionHandlers(this IServiceCollection services, bool withDefaultHandlers = true)
    {
        services.AddSingleton<IExceptionHandlerInvoker, ExceptionHandlerInvoker>();

        if (withDefaultHandlers)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddExceptionHandlersFrom(assembly);
        }
    }

    public static void AddExceptionHandlersFrom(this IServiceCollection services, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            services.AddAllClosedTypes(assembly, typeof(IExceptionHandler<>), ServiceLifetime.Singleton);
        }
    }

    public static IServiceCollection AddAllClosedTypes(
        this IServiceCollection services,
        Assembly assembly,
        Type openInterfaceType,
        ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        foreach (var implementationType in assembly.DefinedTypes.Where(x => x.IsClass && !x.IsAbstract))
        {
            foreach (var interfaceType in implementationType.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == openInterfaceType)
                {
                    services.Add(new ServiceDescriptor(interfaceType, implementationType, lifetime));
                }
            }
        }

        return services;
    }

}

