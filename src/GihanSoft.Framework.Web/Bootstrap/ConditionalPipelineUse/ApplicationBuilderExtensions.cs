using Microsoft.AspNetCore.Builder;

namespace GihanSoft.Framework.Web.Bootstrap.ConditionalPipelineUse;

public static class ApplicationBuilderExtensions
{
    public static ConditionalApplicationBuilder If(this IApplicationBuilder app, bool condition)
    {
        _ = app ?? throw new ArgumentNullException(nameof(app));
        return new ConditionalApplicationBuilder(app, condition);
    }
}
