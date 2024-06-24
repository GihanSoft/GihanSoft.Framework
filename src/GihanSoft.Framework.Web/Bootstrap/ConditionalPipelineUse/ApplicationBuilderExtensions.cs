using Microsoft.AspNetCore.Builder;

namespace GihanSoft.Framework.Web.Bootstrap.ConditionalPipelineUse;

/// <summary>
/// <see cref="IApplicationBuilder"/> extension methods for conditional pipeline registration
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// register pipelines in <paramref name="func"/> if <paramref name="condition"/> is <see langword="true"/>
    /// </summary>
    /// <param name="app"></param>
    /// <param name="condition"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static IApplicationBuilder If(this IApplicationBuilder app, bool condition, Func<IApplicationBuilder, IApplicationBuilder> func)
    {
        ArgumentNullException.ThrowIfNull(app);
        ArgumentNullException.ThrowIfNull(func);

        return condition ? func(app) : app;
    }
}
