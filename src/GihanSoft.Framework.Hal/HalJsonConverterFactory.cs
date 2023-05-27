using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GihanSoft.Framework.Hal;

[SuppressMessage("Build", "CA1812:'HalJsonConverterFactory' is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it 'static' (Module in Visual Basic).", Justification = "dynamic accessed")]
internal sealed class HalJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.GetGenericTypeDefinition() == typeof(HalDocument<>);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var type = typeof(HalJsonConverter<>).MakeGenericType(typeToConvert.GenericTypeArguments);
        return Activator.CreateInstance(type) as JsonConverter;
    }
}
