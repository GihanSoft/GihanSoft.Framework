using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace GihanSoft.Framework.Web.Bootstrap.Initializers;

public static class InitializerHelper
{
    public static async Task RunInitializersAsync(IServiceProvider serviceProvider, IEnumerable<Assembly> assemblies)
    {
        var interfaceType = typeof(IInitializer);
        var groupTasks = assemblies
            .SelectMany(asm => asm.GetExportedTypes())
            .Where(type => !type.IsAbstract && type.IsAssignableTo(interfaceType))
            .GroupBy(type =>
            {
                const string priorityName = nameof(IInitializer.Priority);
                var priorityValue = type.GetProperty(priorityName)?.GetValue(null);
                return priorityValue as int? ?? 0;
            })
            .OrderByDescending(g => g.Key)
            .Select(g => g.Select(type =>
            {
                async Task RunInit()
                {
                    var scope = serviceProvider.CreateAsyncScope();
                    await using (scope.ConfigureAwait(false))
                    {
                        await ((IInitializer)ActivatorUtilities.CreateInstance(scope.ServiceProvider, type))
                            .InitializeAsync()
                            .ConfigureAwait(false);
                    }
                }

                return RunInit();
            }));

        foreach (var t in groupTasks)
        {
            await Task.WhenAll(t).ConfigureAwait(false);
        }
    }

    public static Task RunInitializersAsync(IServiceProvider serviceProvider, params Assembly[] assemblies)
    {
        return RunInitializersAsync(serviceProvider, assemblies.AsEnumerable());
    }

    public static Task RunInitializersAsync(IServiceProvider serviceProvider, IEnumerable<Type> types)
    {
        return RunInitializersAsync(serviceProvider, types.Select(t => t.Assembly));
    }

    public static Task RunInitializersAsync(IServiceProvider serviceProvider, params Type[] types)
    {
        return RunInitializersAsync(serviceProvider, types.Select(t => t.Assembly));
    }

    public static Task RunInitializersAsync<TMarkerType>(IServiceProvider serviceProvider)
    {
        return RunInitializersAsync(serviceProvider, typeof(TMarkerType).Assembly);
    }

    public static Task RunInitializersAsync<TMarker1, TMarker2>(IServiceProvider serviceProvider)
    {
        return RunInitializersAsync(serviceProvider, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly);
    }

    public static Task RunInitializersAsync<TMarker1, TMarker2, TMarker3>(IServiceProvider serviceProvider)
    {
        return RunInitializersAsync(serviceProvider, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly);
    }

    public static Task RunInitializersAsync<TMarker1, TMarker2, TMarker3, TMarker4>(IServiceProvider serviceProvider)
    {
        return RunInitializersAsync(serviceProvider, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly, typeof(TMarker4).Assembly);
    }
}
