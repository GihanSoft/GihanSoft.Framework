using System.Reflection;

using GihanSoft.Framework.Web.Bootstrap.Endpoints;

using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder;

public static class EndpointSetupExtensions
{
    public static TEndpointRouteBuilder MapEndpointSetups<TEndpointRouteBuilder>(
        this TEndpointRouteBuilder endpointRouteBuilder,
        IEnumerable<Assembly> assemblies)
        where TEndpointRouteBuilder : IEndpointRouteBuilder
    {
        var interfaceType = typeof(IEndpointSetup);
        var types = assemblies.Distinct()
            .SelectMany(asm => asm.GetExportedTypes())
            .Where(type => !type.IsAbstract && type.IsAssignableTo(interfaceType));

        foreach (var t in types)
        {
            using var scope = endpointRouteBuilder.ServiceProvider.CreateScope();

            var setup = (IEndpointSetup)ActivatorUtilities.CreateInstance(scope.ServiceProvider, t);
            setup.ConfigureEndpoints(endpointRouteBuilder);
        }

        return endpointRouteBuilder;
    }

    public static TEndpointRouteBuilder MapEndpointSetups<TEndpointRouteBuilder>(
        this TEndpointRouteBuilder endpointRouteBuilder,
        params Assembly[] assemblies)
        where TEndpointRouteBuilder : IEndpointRouteBuilder
    {
        return MapEndpointSetups(endpointRouteBuilder, assemblies.AsEnumerable());
    }

    public static TEndpointRouteBuilder MapEndpointSetups<TEndpointRouteBuilder>(
        this TEndpointRouteBuilder endpointRouteBuilder,
        IEnumerable<Type> types)
        where TEndpointRouteBuilder : IEndpointRouteBuilder
    {
        return MapEndpointSetups(endpointRouteBuilder, types.Select(t => t.Assembly).AsEnumerable());
    }

    public static TEndpointRouteBuilder MapEndpointSetups<TEndpointRouteBuilder>(
        this TEndpointRouteBuilder endpointRouteBuilder,
        params Type[] types)
        where TEndpointRouteBuilder : IEndpointRouteBuilder
    {
        return MapEndpointSetups(endpointRouteBuilder, types.Select(t => t.Assembly).AsEnumerable());
    }

    public static TEndpointRouteBuilder MapEndpointSetups<TEndpointRouteBuilder, TMarker>(this TEndpointRouteBuilder endpointRouteBuilder)
        where TEndpointRouteBuilder : IEndpointRouteBuilder
    {
        return MapEndpointSetups(endpointRouteBuilder, typeof(TMarker).Assembly);
    }

    public static TEndpointRouteBuilder MapEndpointSetups<TEndpointRouteBuilder, TMarker1, TMarker2>(this TEndpointRouteBuilder endpointRouteBuilder)
        where TEndpointRouteBuilder : IEndpointRouteBuilder
    {
        return MapEndpointSetups(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly);
    }

    public static TEndpointRouteBuilder MapEndpointSetups<TEndpointRouteBuilder, TMarker1, TMarker2, TMarker3>(this TEndpointRouteBuilder endpointRouteBuilder)
        where TEndpointRouteBuilder : IEndpointRouteBuilder
    {
        return MapEndpointSetups(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly);
    }

    public static TEndpointRouteBuilder MapEndpointSetups<TEndpointRouteBuilder, TMarker1, TMarker2, TMarker3, TMarker4>(this TEndpointRouteBuilder endpointRouteBuilder)
        where TEndpointRouteBuilder : IEndpointRouteBuilder
    {
        return MapEndpointSetups(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly, typeof(TMarker4).Assembly);
    }

    public static IEndpointRouteBuilder MapEndpointSetups<TMarker>(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return MapEndpointSetups(endpointRouteBuilder, typeof(TMarker).Assembly);
    }

    public static IEndpointRouteBuilder MapEndpointSetups<TMarker1, TMarker2>(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return MapEndpointSetups(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly);
    }

    public static IEndpointRouteBuilder MapEndpointSetups<TMarker1, TMarker2, TMarker3>(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return MapEndpointSetups(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly);
    }

    public static IEndpointRouteBuilder MapEndpointSetups<TMarker1, TMarker2, TMarker3, TMarker4>(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return MapEndpointSetups(endpointRouteBuilder, typeof(TMarker1).Assembly, typeof(TMarker2).Assembly, typeof(TMarker3).Assembly, typeof(TMarker4).Assembly);
    }
}
