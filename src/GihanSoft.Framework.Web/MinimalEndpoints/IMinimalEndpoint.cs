using Microsoft.AspNetCore.Builder;

namespace GihanSoft.Framework.Web.MinimalEndpoints;

public interface IMinimalEndpoint
{
    string Pattern { get; }
    IEnumerable<string> Methods { get; }

    void ConfigureEndpoint(RouteHandlerBuilder builder);

    static abstract Delegate Handler { get; }
}
