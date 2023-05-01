using System.Reflection;

using Microsoft.AspNetCore.Builder;

namespace GihanSoft.Framework.Web.Bootstrap.Initializers;

public static class InitializerWebApplicationExtensions
{
    public static Task RunInitializersAsync(this WebApplication app, IEnumerable<Assembly> assemblies)
    {
        _ = app ?? throw new ArgumentNullException(nameof(app));

        return Framework.Bootstrap.Initializers.InitializerHelper.RunInitializersAsync(app.Services, assemblies);
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

    public static Task RunInitializersAsync<TMarkerType>(this WebApplication app)
    {
        return RunInitializersAsync(app, typeof(TMarkerType).Assembly);
    }

    public static Task RunInitializersAsync<T1, T2>(this WebApplication app)
    {
        return RunInitializersAsync(app, typeof(T1).Assembly, typeof(T2).Assembly);
    }

    public static Task RunInitializersAsync<T1, T2, T3>(this WebApplication app)
    {
        return RunInitializersAsync(app, typeof(T1).Assembly, typeof(T2).Assembly, typeof(T3).Assembly);
    }

    public static Task RunInitializersAsync<T1, T2, T3, T4>(this WebApplication app)
    {
        return RunInitializersAsync(app, typeof(T1).Assembly, typeof(T2).Assembly, typeof(T3).Assembly, typeof(T4).Assembly);
    }
}
