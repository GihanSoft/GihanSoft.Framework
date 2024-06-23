namespace GihanSoft.Framework.Web.Swagger;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public sealed class SwaggerSchemaAttribute(string schemaId) : Attribute
{
    public string SchemaId { get; } = schemaId;
}
