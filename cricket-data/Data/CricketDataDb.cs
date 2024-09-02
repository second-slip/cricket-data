using Microsoft.EntityFrameworkCore;

namespace cricket_data.data;

public class CricketDataDb : DbContext
{
    public CricketDataDb(DbContextOptions<CricketDataDb> options)
        : base(options) { }

    public DbSet<Ground> Grounds => Set<Ground>();
    public DbSet<Player> Players => Set<Player>();
    public DbSet<BowlingInnings> BowlingInnings => Set<BowlingInnings>();
}