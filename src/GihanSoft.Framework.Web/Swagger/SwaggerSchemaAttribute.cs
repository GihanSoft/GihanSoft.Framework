namespace GihanSoft.Framework.Web.Swagger;

/// <summary>
/// Custom attribute to specify scheme id for swagger.
/// can be utilized with <see cref="SwaggerSchemaAttributeIdSelector.SchemaSelector(Type)"/>
/// </summary>
/// <param name="schemaId"></param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public sealed class SwaggerSchemaAttribute(string schemaId) : Attribute
{
    /// <summary>
    /// custom scheme id for swagger
    /// </summary>
    public string SchemaId { get; } = schemaId;
}
