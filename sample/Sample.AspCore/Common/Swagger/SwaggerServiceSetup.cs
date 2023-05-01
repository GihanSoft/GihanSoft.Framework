using GihanSoft.Framework.Bootstrap.Services;

namespace Sample.AspCore.Common.Swagger;

public class SwaggerServiceSetup : IServiceSetup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
    }
}
