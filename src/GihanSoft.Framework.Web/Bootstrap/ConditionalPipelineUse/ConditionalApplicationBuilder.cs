using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace GihanSoft.Framework.Web.Bootstrap.ConditionalPipelineUse;

public readonly struct ConditionalApplicationBuilder : IApplicationBuilder, IEquatable<ConditionalApplicationBuilder>
{
    private readonly IApplicationBuilder _realAppBuilder;
    private readonly bool _condition;

    public ConditionalApplicationBuilder(IApplicationBuilder app, bool condition)
    {
        _realAppBuilder = app;
        _condition = condition;
    }

    public IServiceProvider ApplicationServices
    {
        get => _realAppBuilder.ApplicationServices;
        set => _realAppBuilder.ApplicationServices = value;
    }
    public IFeatureCollection ServerFeatures => _realAppBuilder.ServerFeatures;
    public IDictionary<string, object?> Properties => _realAppBuilder.Properties;

    public RequestDelegate Build()
    {
        return _realAppBuilder.Build();
    }

    public IApplicationBuilder New()
    {
        return _realAppBuilder.New();
    }

    public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
    {
        return _condition ? _realAppBuilder.Use(middleware) : _realAppBuilder;
    }

    public static bool operator ==(ConditionalApplicationBuilder left, ConditionalApplicationBuilder right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ConditionalApplicationBuilder left, ConditionalApplicationBuilder right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_condition, _realAppBuilder);
    }

    public override bool Equals(object? obj)
    {
        return obj is ConditionalApplicationBuilder other && Equals(other);
    }

    public bool Equals(ConditionalApplicationBuilder other)
    {
        return _condition == other._condition && _realAppBuilder == other._realAppBuilder;
    }
}
