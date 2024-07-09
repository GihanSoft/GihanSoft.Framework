using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace GihanSoft.Framework.Web.Hal;

/// <summary>
/// HAL link object
/// </summary>
public class HalLink
{
    /// <summary>
    /// parameterless constructor.
    /// </summary>
    public HalLink() { }

    /// <summary>
    /// constructor with <paramref name="href"/>
    /// </summary>
    /// <param name="href"></param>
    [SetsRequiredMembers]
    public HalLink(string href) { Href = href; }

    /// <summary>
    /// <para>
    ///     Its value is either a URI <see href="https://www.rfc-editor.org/info/rfc3986">[RFC3986]</see> or
    ///     a URI Template <see href="https://www.rfc-editor.org/info/rfc6570">[RFC6570]</see>.
    /// </para>
    /// <para>
    ///     If the value is a URI Template then the Link Object SHOULD have a "templated" attribute whose value is true.
    /// </para>
    /// </summary>
    public required string Href { get; set; }

    /// <summary>
    /// <para>
    ///     Its value is boolean and SHOULD be true when the Link Object's "href" property is a URI Template.
    /// </para>
    /// <para>
    ///     Its value SHOULD be considered false if it is undefined or any other value than true.
    /// </para>
    /// </summary>
    public bool? Templated { get; set; }

    /// <summary>
    /// Its value is a string used as a hint to indicate the media type expected when dereferencing the target resource.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// <para>
    /// Its presence indicates that the link is to be deprecated (i.e. removed) at a future date.
    /// Its value is a URL that SHOULD provide further information about the deprecation.
    /// </para>
    /// <para>
    /// A client SHOULD provide some notification(for example, by logging a warning message) whenever it traverses over a link that has this property.
    /// The notification SHOULD include the deprecation property's value so that a client maintainer can easily find information about the deprecation.
    /// </para>
    /// </summary>
    public string? Deprecation { get; set; }

    /// <summary>
    /// Its value MAY be used as a secondary key for selecting Link Objects which share the same relation type.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Its value is a string which is a URI that hints about the profile
    /// (as defined by <see href="https://www.rfc-editor.org/info/rfc6906">[RFC6906]</see>)
    /// of the target resource.
    /// </summary>
    public string? Profile { get; set; }

    /// <summary>
    /// Its value is a string and is intended for labelling the link with a human-readable identifier
    /// (as defined by <see href="https://www.rfc-editor.org/info/rfc5988">[RFC5988]</see>).
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Its value is a string and is intended for indicating the language of the target resource
    /// (as defined by <see href="https://www.rfc-editor.org/info/rfc5988">[RFC5988]</see>).
    /// </summary>
    [JsonPropertyName("hreflang")]
    public string? HrefLang { get; set; }

    /// <summary>
    /// Create a <see cref="HalLink"/> from string <paramref name="href"/>
    /// </summary>
    /// <param name="href"></param>
    /// <returns></returns>
    public static HalLink FromString(string href) => new(href);

    /// <summary>
    /// implicit convertor from string <paramref name="href"/>
    /// </summary>
    /// <param name="href"></param>
    public static implicit operator HalLink(string href) => new(href);
}
