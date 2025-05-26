using Microsoft.EntityFrameworkCore;

namespace DinasPendidikan.Database;

public class DinasPendidikanDbContext: DbContext
{
    public DinasPendidikanDbContext(DbContextOptions<DinasPendidikanDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
