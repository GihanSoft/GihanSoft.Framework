using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GihanSoft.Framework.Web.Bootstrap.Initialization;

/// <summary>
/// <see cref="WebApplication"/> extension methods for running initializers
/// </summary>
public static class InitializationWebApplicationExtensions
{
    /// <summary>
    /// Run initializers
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static Task RunInitializersAsync(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        return RunInitializersAsync(app.Services);
    }

    /// <summary>
    /// Run initializers
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static Task RunInitializersAsync(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        return RunInitializersAsync(app.ApplicationServices);
    }

    /// <summary>
    /// Run initializers
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static Task RunInitializersAsync(this IHost app)
    {
        ArgumentNullException.ThrowIfNull(app);

        return RunInitializersAsync(app.Services);
    }

    /// <summary>
    /// Run initializers
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static Task RunInitializersAsync(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        return RunInitializersAsync(app.ServiceProvider);
    }

    private static async Task RunInitializersAsync(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateAsyncScope();
        await using var scopeDisposable = scope.ConfigureAwait(false);

        var groupTasks = scope.ServiceProvider.GetServices<IInitializer>()
            .GroupBy(x => x.Priority)
            .OrderByDescending(g => g.Key);

        foreach (var group in groupTasks)
        {
            var tasks = group.AsParallel().Select(x => x.InitializeAsync());
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
