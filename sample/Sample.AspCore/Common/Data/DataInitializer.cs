using GihanSoft.Framework.Web.Bootstrap.Initializers;

using Microsoft.EntityFrameworkCore;

namespace Sample.AspCore.Common.Data;

public class DataInitializer : IInitializer
{
    private readonly AppDbContext db;

    public DataInitializer(AppDbContext db)
    {
        this.db = db;
    }

    public static int Priority { get; }

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
