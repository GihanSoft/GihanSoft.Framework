using GihanSoft.Framework.Web.Swagger;

namespace Sample.AspCore.Features.Notes;

[SwaggerSchema("note")]
public class NoteEntity
{
    public required int Id { get; init; }

    public required string Title { get; init; }
    public required string Content { get; init; }

    public DateTime CreationMoment { get; init; }
    public DateTime UpdateMoment { get; init; }

    public required string ConcurrencyToken { get; init; }
}
