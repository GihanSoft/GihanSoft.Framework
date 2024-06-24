using Microsoft.EntityFrameworkCore;

namespace Sample.AspCore.Common.Data;

internal partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
