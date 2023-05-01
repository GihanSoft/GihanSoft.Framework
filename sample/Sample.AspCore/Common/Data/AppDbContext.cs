using Microsoft.EntityFrameworkCore;

namespace Sample.AspCore.Common.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
