using System.Reflection;

namespace GihanSoft.Framework.Web.Swagger;

/// <summary>
/// Method container for <see cref="SchemaSelector(Type)"/>
/// </summary>
public static class SwaggerSchemaAttributeIdSelector
{
    /// <summary>
    /// custom scheme selector that utilize <see cref="SwaggerSchemaAttribute"/>
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string SchemaSelector(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        var attribute = type.GetCustomAttribute<SwaggerSchemaAttribute>();
        return attribute is not null ? attribute.SchemaId : type.Name;
    }
}
