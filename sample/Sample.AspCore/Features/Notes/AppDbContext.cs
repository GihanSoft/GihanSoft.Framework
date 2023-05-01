using Microsoft.EntityFrameworkCore;

using Sample.AspCore.Features.Notes;

namespace Sample.AspCore.Common.Data;

public partial class AppDbContext
{
    public required DbSet<NoteEntity> Notes { get; init; }
}
