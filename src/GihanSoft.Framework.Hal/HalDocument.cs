using System.Text.Json.Serialization;

namespace GihanSoft.Framework.Hal;

public static class HalDocument
{
    public static HalDocument<T> From<T>(
        T resource,
        IDictionary<string, HalLink>? links = null,
        IDictionary<string, object>? embedded = null)
        where T : notnull
    {
        return new HalDocument<T>()
        {
            Resource = resource,
            Links = links?.AsReadOnly(),
            Embedded = embedded?.AsReadOnly(),
        };
    }
}

[JsonConverter(typeof(HalJsonConverterFactory))]
public class HalDocument<T>
{
    public required T Resource { get; init; }

    [JsonPropertyName("_links")]
    public IReadOnlyDictionary<string, HalLink>? Links { get; init; }

    [JsonPropertyName("_embedded")]
    public IReadOnlyDictionary<string, object>? Embedded { get; init; }
}
