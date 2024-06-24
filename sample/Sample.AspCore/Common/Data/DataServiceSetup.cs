
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Sample.AspCore.Common.Data;

internal static class DataServiceSetup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((serviceProvider, opt) =>
        {
            var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            opt.UseSqlite(configuration.GetConnectionString("main-db"));

            if (environment.IsDevelopment())
            {
                opt.EnableSensitiveDataLogging();
                opt.EnableDetailedErrors();
            }
        });

        services.TryAddEnumerable(new ServiceDescriptor(typeof(DbContext), typeof(AppDbContext), ServiceLifetime.Scoped));
    }
}
