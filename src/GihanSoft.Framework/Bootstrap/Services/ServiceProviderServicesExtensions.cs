using System.Reflection;

using GihanSoft.Framework.Bootstrap.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderServicesExtensions
{
    public static IServiceCollection AddServiceSetups(
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

    public static IServiceCollection AddServiceSetups(this IServiceCollection services, IServiceProvider serviceProvider, params Assembly[] assemblies)
    {
        return AddServiceSetups(services, serviceProvider, assemblies.AsEnumerable());
    }

    public static IServiceCollection AddServiceSetups(this IServiceCollection services, IServiceProvider serviceProvider, IEnumerable<Type> types)
    {
        return AddServiceSetups(services, serviceProvider, types.Select(t => t.Assembly));
    }

    public static IServiceCollection AddServiceSetups(this IServiceCollection services, IServiceProvider serviceProvider, params Type[] types)
    {
        return AddServiceSetups(services, serviceProvider, types.Select(t => t.Assembly));
    }

    public static IServiceCollection AddServiceSetups<TMarker>(this IServiceCollection services, IServiceProvider serviceProvider)
    {
        return AddServiceSetups(services, serviceProvider, typeof(TMarker).Assembly);
    }

    public static IServiceCollection AddServiceSetups<TMarker1, TMarker2>(this IServiceCollection services, IServiceProvider serviceProvider)
    {
        return AddServiceSetups(services, serviceProvider, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly);
    }

    public static IServiceCollection AddServiceSetups<TMarker1, TMarker2, TMarker3>(this IServiceCollection services, IServiceProvider serviceProvider)
    {
        return AddServiceSetups(services, serviceProvider, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly);
    }

    public static IServiceCollection AddServiceSetups<TMarker1, TMarker2, TMarker3, TMarker4>(this IServiceCollection services, IServiceProvider serviceProvider)
    {
        return AddServiceSetups(services, serviceProvider, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly, typeof(TMarker4).Assembly);
    }
}
