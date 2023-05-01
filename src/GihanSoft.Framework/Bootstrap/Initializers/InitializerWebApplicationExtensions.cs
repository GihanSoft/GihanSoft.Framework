using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace GihanSoft.Framework.Bootstrap.Initializers;

public static class InitializerWebApplicationExtensions
{
    public static async Task RunInitializersAsync(IServiceProvider serviceProvider, IEnumerable<Assembly> assemblies)
    {
        var interfaceType = typeof(IInitializer);
        var groups = assemblies
            .SelectMany(asm => asm.GetExportedTypes())
            .Where(type => !type.IsAbstract && type.IsAssignableTo(interfaceType))
            .GroupBy(GetPriority)
            .OrderByDescending(g => g.Key);

        foreach (var g in groups)
        {
            var groupTasks = g.Select(type =>
            {
                async Task RunInit()
                {
                    await using var scope = serviceProvider.CreateAsyncScope().ConfigureAwait(false);
                    await ((IInitializer)ActivatorUtilities.CreateInstance(serviceProvider, type)).InitializeAsync().ConfigureAwait(false);
                }

                return RunInit();
            });

            await Task.WhenAll(groupTasks).ConfigureAwait(false);
        }
    }

    private static int GetPriority(Type type)
    {
        return (int)(type.GetProperty(nameof(IInitializer.Priority))?.GetValue(null) ?? 0);
    }
}
