using Microsoft.AspNetCore.Routing;

namespace GihanSoft.Framework.Web.Bootstrap.Endpoints;

public interface IEndpointSetup
{
    void ConfigureEndpoints(IEndpointRouteBuilder endpointRouteBuilder);
}
