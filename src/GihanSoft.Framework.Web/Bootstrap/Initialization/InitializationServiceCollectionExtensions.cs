using Microsoft.Extensions.DependencyInjection;

namespace GihanSoft.Framework.Web.Bootstrap.Initialization;

/// <summary>
/// <see cref="IServiceCollection"/> extension methods for running initializers
/// </summary>
public static class InitializationServiceCollectionExtensions
{
    /// <summary>
    /// Run initializers
    /// </summary>
    /// <typeparam name="TInitializer"></typeparam>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInitializer<TInitializer>(this IServiceCollection services)
        where TInitializer : class, IInitializer
    {
        ArgumentNullException.ThrowIfNull(services);

        return services.AddScoped<IInitializer, TInitializer>();
    }
}
