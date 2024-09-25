using Microsoft.EntityFrameworkCore;

namespace cricket_data.services;

public interface IBowlingInningsService
{
    Task<IReadOnlyList<BowlingInningsDto>> GetBowlingInningsAsync(int id);
}

public class BowlingInningsService : IBowlingInningsService
{
    private readonly CricketDataDb _db;
    public BowlingInningsService(CricketDataDb db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<BowlingInningsDto>> GetBowlingInningsAsync(int id)
    {
        var query = _db.BowlingInnings
            .Where(t => t.PlayerId == id)
            .MapBowlingInningsModelToDto()    
            .AsNoTracking()
            .AsQueryable();

        return await query.ToListAsync();
    }
}