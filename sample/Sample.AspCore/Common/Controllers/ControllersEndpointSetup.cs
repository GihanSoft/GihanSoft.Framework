using GihanSoft.Framework.Web.Bootstrap.Endpoints;

namespace Sample.AspCore.Common.Controllers;

public class ControllersEndpointSetup : IEndpointSetup
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapControllers();
    }
}
