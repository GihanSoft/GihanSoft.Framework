using Microsoft.AspNetCore.Builder;

namespace GihanSoft.Framework.Web.MinimalEndpoints;

public interface IMinimalEndpoint
{
    string Pattern { get; }
    IEnumerable<HttpMethod> HttpMethods { get; }

    void ConfigureEndpoint(IEndpointConventionBuilder endpointConventionBuilder);

    static abstract Delegate Handler { get; }
}
