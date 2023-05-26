using System.Reflection;

using Microsoft.AspNetCore.Builder;

namespace GihanSoft.Framework.Web.Bootstrap.Initializers;

public static class InitializerWebApplicationExtensions
{
    public static Task RunInitializersAsync(this WebApplication app, IEnumerable<Assembly> assemblies)
    {
        _ = app ?? throw new ArgumentNullException(nameof(app));

        return InitializerHelper.RunInitializersAsync(app.Services, assemblies);
    }

    public static Task RunInitializersAsync(this WebApplication app, params Assembly[] assemblies)
    {
        return RunInitializersAsync(app, assemblies.AsEnumerable());
    }

    public static Task RunInitializersAsync(this WebApplication app, IEnumerable<Type> types)
    {
        return RunInitializersAsync(app, types.Select(t => t.Assembly));
    }

    public static Task RunInitializersAsync(this WebApplication app, params Type[] types)
    {
        return RunInitializersAsync(app, types.Select(t => t.Assembly));
    }

    public static Task RunInitializersAsync<TMarker>(this WebApplication app)
    {
        return RunInitializersAsync(app, typeof(TMarker).Assembly);
    }

    public static Task RunInitializersAsync<TMarker1, TMarker2>(this WebApplication app)
    {
        return RunInitializersAsync(app, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly);
    }

    public static Task RunInitializersAsync<TMarker1, TMarker2, TMarker3>(this WebApplication app)
    {
        return RunInitializersAsync(app, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly);
    }

    public static Task RunInitializersAsync<TMarker1, TMarker2, TMarker3, TMarker4>(this WebApplication app)
    {
        return RunInitializersAsync(app, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly, typeof(TMarker4).Assembly);
    }
}
