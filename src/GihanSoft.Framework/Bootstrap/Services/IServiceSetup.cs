using Microsoft.Extensions.DependencyInjection;

namespace GihanSoft.Framework.Bootstrap.Services;

public interface IServiceSetup
{
    void ConfigureServices(IServiceCollection services);
}
