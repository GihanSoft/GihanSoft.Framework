using System.Reflection;

using GihanSoft.Framework.Web.MinimalEndpoints;

using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder;

public static class MinimalEndpointExtensions
{
    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder>(this TRouteBuilder endpointRouteBuilder, IEnumerable<Assembly> assemblies)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        var interfaceType = typeof(IMinimalEndpoint);

        var types = assemblies
            .SelectMany(asm => asm.GetExportedTypes())
            .Where(type => !type.IsAbstract && type.IsAssignableTo(interfaceType));

        foreach (var t in types)
        {
            var handler = t.GetProperty(nameof(IMinimalEndpoint.Handler))?.GetValue(null) as Delegate ??
                throw new InvalidOperationException($"handler of minimal endpoint in type '{t.FullName}' is null");
            using var scope = endpointRouteBuilder.ServiceProvider.CreateScope();

            var endpoint = (IMinimalEndpoint)ActivatorUtilities.CreateInstance(scope.ServiceProvider, t);
            var routeHandlerBuilder = endpointRouteBuilder.MapMethods(endpoint.Pattern, endpoint.HttpMethods.Select(m => m.Method), handler);
            endpoint.ConfigureEndpoint(routeHandlerBuilder);
        }

        return endpointRouteBuilder;
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder>(this TRouteBuilder endpointRouteBuilder, params Assembly[] assemblies)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpointRouteBuilder, assemblies.AsEnumerable());
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder>(this TRouteBuilder endpointRouteBuilder, IEnumerable<Type> types)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpointRouteBuilder, types.Select(t => t.Assembly));
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder>(this TRouteBuilder endpointRouteBuilder, params Type[] types)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpointRouteBuilder, types.Select(t => t.Assembly));
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder, TMarker>(this TRouteBuilder endpointRouteBuilder)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpointRouteBuilder, typeof(TMarker).Assembly);
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder, TMarker1, TMarker2>(this TRouteBuilder endpointRouteBuilder)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly);
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder, TMarker1, TMarker2, TMarker3>(this TRouteBuilder endpointRouteBuilder)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly);
    }

    public static TRouteBuilder MapMinimalEndpoints<TRouteBuilder, TMarker1, TMarker2, TMarker3, TMarker4>(this TRouteBuilder endpointRouteBuilder)
        where TRouteBuilder : IEndpointRouteBuilder
    {
        return MapMinimalEndpoints(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly, typeof(TMarker4).Assembly);
    }

    public static IEndpointRouteBuilder MapMinimalEndpoints<TMarker>(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return MapMinimalEndpoints(endpointRouteBuilder, typeof(TMarker).Assembly);
    }

    public static IEndpointRouteBuilder MapMinimalEndpoints<TMarker1, TMarker2>(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return MapMinimalEndpoints(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly);
    }

    public static IEndpointRouteBuilder MapMinimalEndpoints<TMarker1, TMarker2, TMarker3>(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return MapMinimalEndpoints(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly);
    }

    public static IEndpointRouteBuilder MapMinimalEndpoints<TMarker1, TMarker2, TMarker3, TMarker4>(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return MapMinimalEndpoints(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly, typeof(TMarker4).Assembly);
    }
}
