using System.Reflection;

namespace GihanSoft.Framework.Web.Swagger;

public static class SwaggerSchemaAttributeIdSelector
{
    public static string SchemaSelector(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        var attribute = type.GetCustomAttribute<SwaggerSchemaAttribute>();
        return attribute is not null ? attribute.SchemaId : type.Name;
    }
}
