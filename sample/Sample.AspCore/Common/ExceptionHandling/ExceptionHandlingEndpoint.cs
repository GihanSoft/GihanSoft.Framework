using GihanSoft.Framework.Web.MinimalEndpoints;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Sample.AspCore.Common.ExceptionHandling;

public sealed class ExceptionHandlingEndpoint : IMinimalEndpoint
{
    public string Pattern => "/500";
    public IEnumerable<HttpMethod> HttpMethods => new[] { HttpMethod.Get };

    public void ConfigureEndpoint(IEndpointConventionBuilder builder) =>
        builder.ExcludeFromDescription();

    public static Delegate Handler => HandleAsync;

    public static ValueTask<ProblemHttpResult> HandleAsync()
    {
        return ValueTask.FromResult(TypedResults.Problem());
    }
}
