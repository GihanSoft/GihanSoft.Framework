using Bootstrap;

using GihanSoft.Framework.Web.Bootstrap.Initializers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFromServiceDescriptionProviders<Program>(new BootstrapServiceProvider(builder));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapMinimalEndpoints<Program>();

await app.RunInitializersAsync<Program>().ConfigureAwait(false);
await app.RunAsync().ConfigureAwait(false);

namespace Bootstrap
{
    internal class BootstrapServiceProvider : IServiceProvider
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
}
