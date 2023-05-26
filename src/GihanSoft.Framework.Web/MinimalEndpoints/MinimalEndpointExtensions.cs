using System.Reflection;

using GihanSoft.Framework.Web.MinimalEndpoints;

using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder;

public static class MinimalEndpointExtensions
{
    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder>(this TRouteBuilder endpoints, IEnumerable<Assembly> assemblies)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        var interfaceType = typeof(IMinimalEndpoint);

        var types = assemblies
            .SelectMany(asm => asm.GetExportedTypes())
            .Where(type => !type.IsAbstract && type.IsAssignableTo(interfaceType));

        foreach (var t in types)
        {
            using var scope = endpoints.ServiceProvider.CreateScope();

            var handler = t.GetProperty(nameof(IMinimalEndpoint.Handler))?.GetValue(null) as Delegate ??
                throw new InvalidOperationException($"handler of minimal endpoint in type '{t.FullName}' is null");

            var endpoint = (IMinimalEndpoint)ActivatorUtilities.CreateInstance(scope.ServiceProvider, t);
            var routeHandlerBuilder = endpoints.MapMethods(endpoint.Pattern, endpoint.Methods, handler);
            endpoint.ConfigureEndpoint(routeHandlerBuilder);
        }

        return endpoints;
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder>(this TRouteBuilder endpoints, params Assembly[] assemblies)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpoints, assemblies.AsEnumerable());
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder>(this TRouteBuilder endpoints, IEnumerable<Type> types)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpoints, types.Select(t => t.Assembly));
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder>(this TRouteBuilder endpoints, params Type[] types)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpoints, types.Select(t => t.Assembly));
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder, TMarker>(this TRouteBuilder endpoints)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpoints, typeof(TMarker).Assembly);
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder, TMarker1, TMarker2>(this TRouteBuilder endpoints)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpoints, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly);
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder, TMarker1, TMarker2, TMarker3>(this TRouteBuilder endpoints)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpoints, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly);
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder, TMarker1, TMarker2, TMarker3, TMarker4>(this TRouteBuilder endpoints)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpoints, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly, typeof(TMarker4).Assembly);
    }

    public static IEndpointRouteBuilder MapMinimalEndpoints<TMarker>(this IEndpointRouteBuilder endpoints)
    {
        return MapMinimalEndpoints(endpoints, typeof(TMarker).Assembly);
    }

    public static IEndpointRouteBuilder MapMinimalEndpoints<TMarker1, TMarker2>(this IEndpointRouteBuilder endpoints)
    {
        return MapMinimalEndpoints(endpoints, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly);
    }

    public static IEndpointRouteBuilder MapMinimalEndpoints<TMarker1, TMarker2, TMarker3>(this IEndpointRouteBuilder endpoints)
    {
        return MapMinimalEndpoints(endpoints, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly);
    }

    public static IEndpointRouteBuilder MapMinimalEndpoints<TMarker1, TMarker2, TMarker3, TMarker4>(this IEndpointRouteBuilder endpoints)
    {
        return MapMinimalEndpoints(endpoints, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly, typeof(TMarker4).Assembly);
    }
}
