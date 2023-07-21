namespace GihanSoft.Framework.Web.Swagger;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public sealed class SwaggerSchemaAttribute : Attribute
{
    public SwaggerSchemaAttribute(string schemaId)
    {
        SchemaId = schemaId;
    }

    public string SchemaId { get; }
}
