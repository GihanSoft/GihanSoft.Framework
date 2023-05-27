namespace GihanSoft.Framework.Hal;

public class HalDocumentBuilder<T>
{
    private readonly T _resource;
    private readonly Dictionary<string, HalLink> _links = new(StringComparer.Ordinal);
    private readonly Dictionary<string, object> _embedded = new(StringComparer.Ordinal);

    public HalDocumentBuilder(T resource)
    {
        _resource = resource;
    }

    public HalDocument<T> Build()
    {
        return new HalDocument<T>
        {
            Resource = _resource,
            Links = _links,
            Embedded = _embedded,
        };
    }

    public HalDocumentBuilder<T> AddLink(string key, HalLink link)
    {
        _links[key] = link;
        return this;
    }

    public HalDocumentBuilder<T> AddSelfLink(HalLink link) => AddLink("self", link);

    public HalDocumentBuilder<T> AddEmbedded(string key, object resource)
    {
        _embedded[key] = resource;
        return this;
    }
}

public static class HalDocumentBuilder
{
    public static HalDocumentBuilder<T> From<T>(T resource) => new(resource);
}
