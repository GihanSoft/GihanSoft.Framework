using GihanSoft.Framework.Web.MinimalEndpoints;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Sample.AspCore.Shared.ExceptionHandling;

public sealed class ExceptionHandlingEndpoint : IMinimalEndpoint
{
    public string Pattern => "/500";
    public IEnumerable<HttpMethod> HttpMethods => new[] { HttpMethod.Get };

    public static Delegate Handler => HandleAsync;

    public static ValueTask<ProblemHttpResult> HandleAsync()
    {
        return ValueTask.FromResult(TypedResults.Problem());
    }

    public void ConfigureEndpoint(IEndpointConventionBuilder endpointConventionBuilder)
    {
        endpointConventionBuilder.ExcludeFromDescription();
    }
}
