using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace GihanSoft.Framework.Hal;

public class HalLink
{
    public HalLink() { }

    [SetsRequiredMembers]
    public HalLink(string href) { Href = href; }

    public required string Href { get; set; }
    public bool? Templated { get; set; }
    public string? Type { get; set; }
    public string? Deprecation { get; set; }
    public string? Name { get; set; }
    public string? Profile { get; set; }
    public string? Title { get; set; }

    [JsonPropertyName("hreflang")]
    public string? HrefLang { get; set; }

    public static HalLink FromString(string href) => new(href);
    public static implicit operator HalLink(string href) => new(href);
}
