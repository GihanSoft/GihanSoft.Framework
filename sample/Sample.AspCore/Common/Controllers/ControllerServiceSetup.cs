using GihanSoft.Framework.Bootstrap.Services;

namespace Sample.AspCore.Common.Controllers;

public class ControllerServiceSetup : IServiceSetup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
    }
}
