using Microsoft.AspNetCore.Builder;

namespace GihanSoft.Framework.Web.Bootstrap.ConditionalPipelineUse;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder If(this IApplicationBuilder app, bool condition, Func<IApplicationBuilder, IApplicationBuilder> func)
    {
        ArgumentNullException.ThrowIfNull(app);
        ArgumentNullException.ThrowIfNull(func);

        return condition ? func(app) : app;
    }
}
