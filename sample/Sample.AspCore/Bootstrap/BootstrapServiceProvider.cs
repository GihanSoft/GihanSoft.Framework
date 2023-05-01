namespace Sample.AspCore.Bootstrap;

internal sealed class BootstrapServiceProvider : IServiceProvider
{
    private readonly IReadOnlyDictionary<Type, object> serviceMap;

    public BootstrapServiceProvider(WebApplicationBuilder builder)
    {
        serviceMap = new Dictionary<Type, object>()
        {
            [typeof(IConfiguration)] = builder.Configuration,
            [typeof(IWebHostEnvironment)] = builder.Environment,
            [typeof(IHostEnvironment)] = builder.Environment,
        };
    }

    public object? GetService(Type serviceType)
    {
        return serviceMap.TryGetValue(serviceType, out var service) ? service : null;
    }
}
