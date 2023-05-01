using System.Reflection;

using GihanSoft.Framework.Bootstrap.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderServicesExtensions
{
    public static IServiceCollection AddFromServiceDescriptionProviders(
        this IServiceCollection services,
        IServiceProvider serviceProvider,
        IEnumerable<Assembly> assemblies)
    {
        var interfaceType = typeof(IServiceSetup);
        return assemblies.Distinct()
            .SelectMany(asm => asm.GetExportedTypes())
            .Where(type => !type.IsAbstract && type.IsAssignableTo(interfaceType))
            .Select(type => (IServiceSetup)ActivatorUtilities.CreateInstance(serviceProvider, type))
            .Select<IServiceSetup, Action<IServiceCollection>>(setup => services => setup.ConfigureServices(services))
            .Aggregate(services, (services, action) =>
            {
                action(services);
                return services;
            });
    }

    public static IServiceCollection AddFromServiceDescriptionProviders(this IServiceCollection services, IServiceProvider serviceProvider, params Assembly[] assemblies)
    {
        return AddFromServiceDescriptionProviders(services, serviceProvider, assemblies.AsEnumerable());
    }

    public static IServiceCollection AddFromServiceDescriptionProviders(this IServiceCollection services, IServiceProvider serviceProvider, IEnumerable<Type> types)
    {
        return AddFromServiceDescriptionProviders(services, serviceProvider, types.Select(t => t.Assembly));
    }

    public static IServiceCollection AddFromServiceDescriptionProviders(this IServiceCollection services, IServiceProvider serviceProvider, params Type[] types)
    {
        return AddFromServiceDescriptionProviders(services, serviceProvider, types.Select(t => t.Assembly));
    }

    public static IServiceCollection AddFromServiceDescriptionProviders<TMarkerType>(this IServiceCollection services, IServiceProvider serviceProvider)
    {
        return AddFromServiceDescriptionProviders(services, serviceProvider, typeof(TMarkerType).Assembly);
    }

    public static IServiceCollection AddFromServiceDescriptionProviders<T1, T2>(this IServiceCollection services, IServiceProvider serviceProvider)
    {
        return AddFromServiceDescriptionProviders(services, serviceProvider, typeof(T1).Assembly, typeof(T2).Assembly);
    }

    public static IServiceCollection AddFromServiceDescriptionProviders<T1, T2, T3>(this IServiceCollection services, IServiceProvider serviceProvider)
    {
        return AddFromServiceDescriptionProviders(services, serviceProvider, typeof(T1).Assembly, typeof(T2).Assembly, typeof(T3).Assembly);
    }

    public static IServiceCollection AddFromServiceDescriptionProviders<T1, T2, T3, T4>(this IServiceCollection services, IServiceProvider serviceProvider)
    {
        return AddFromServiceDescriptionProviders(services, serviceProvider, typeof(T1).Assembly, typeof(T2).Assembly, typeof(T3).Assembly, typeof(T4).Assembly);
    }
}
