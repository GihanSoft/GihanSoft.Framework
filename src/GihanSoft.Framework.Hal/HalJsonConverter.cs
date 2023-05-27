using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace GihanSoft.Framework.Hal;

[SuppressMessage("Build", "CA1812:'HalJsonConverterFactory' is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it 'static' (Module in Visual Basic).", Justification = "dynamic accessed")]
internal sealed class HalJsonConverter<T> : JsonConverter<HalDocument<T>>
{
    public override HalDocument<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return null;
    }

    public override void Write(Utf8JsonWriter writer, HalDocument<T> value, JsonSerializerOptions options)
    {
        var resource = JsonSerializer.SerializeToNode(value.Resource, options);

        var root = resource switch
        {
            JsonObject obj => ObjectResourceToRootWithEmbedded(obj, value.Embedded, options),
            JsonArray or JsonValue => NotObjectResourceToRootWithEmbedded(resource, value.Embedded, options),
            _ => null,
        };

        if (root is null)
        {
            writer.WriteNullValue();
            return;
        }

        if (value.Links?.Count > 0)
        {
            var links = JsonSerializer.SerializeToNode(value.Links, options);
            root.Add("_links", links);
        }

        root.WriteTo(writer, options);
    }

    private static JsonObject ObjectResourceToRootWithEmbedded(
        JsonObject root,
        IReadOnlyDictionary<string, object>? embedded,
        JsonSerializerOptions options)
    {
        if (embedded?.Count > 0)
        {
            var embeddedNode = JsonSerializer.SerializeToNode(embedded, options);
            root.Add("_embedded", embeddedNode);
        }

        return root;
    }

    private static JsonObject NotObjectResourceToRootWithEmbedded(
        JsonNode resource,
        IReadOnlyDictionary<string, object>? embedded,
        JsonSerializerOptions options)
    {
        Dictionary<string, object> embeddedDic =
            embedded?.Count > 0
            ? new(embedded, StringComparer.Ordinal)
            : new(StringComparer.Ordinal);
        embeddedDic["self"] = resource;
        var embeddedNode = JsonSerializer.SerializeToNode(embeddedDic, options);

        var root = new JsonObject(
            new[] { KeyValuePair.Create("_embedded", embeddedNode) },
            new JsonNodeOptions { PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive });

        return root;
    }
}
