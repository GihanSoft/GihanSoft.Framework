using GihanSoft.Framework.Web.Bootstrap.Initialization;

using Microsoft.EntityFrameworkCore;

namespace Sample.AspCore.Common.Data;

internal class DataInitializer(AppDbContext db) : IInitializer
{
    private readonly AppDbContext db = db;

    public int Priority { get; }

    public async Task InitializeAsync()
    {
        var pending = await db.Database
            .GetPendingMigrationsAsync(CancellationToken.None)
            .ContinueWith(t => t.Result.ToArray(), TaskScheduler.Current)
            .ConfigureAwait(false);
        if (pending.Length > 0)
        {
            await db.Database.MigrateAsync(CancellationToken.None).ConfigureAwait(false);
        }
    }
}
