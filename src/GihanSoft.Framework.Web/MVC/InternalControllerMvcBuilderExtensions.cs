using Microsoft.Extensions.DependencyInjection;

namespace GihanSoft.Framework.Web.MVC;

/// <summary>
/// Extension method container for <see cref="IMvcBuilder"/> to include internal controller.
/// </summary>
public static class InternalControllerMvcBuilderExtensions
{
    /// <summary>
    /// Extension method for <see cref="IMvcBuilder"/> to include internal controller.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IMvcBuilder AddInternalControllers(this IMvcBuilder builder) => builder.ConfigureApplicationPartManager(
        x => x.FeatureProviders.Add(new IncludeInternalControllerFeatureProvider()));
}
