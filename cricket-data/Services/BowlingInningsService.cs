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
            .MapObservationToObservationFeedDto()
            .AsNoTracking()
            .AsQueryable();

        return await query.ToListAsync();
    }
}


public static class QueryableExtensions
{
    public static IQueryable<BowlingInningsDto> MapObservationToObservationFeedDto(this IQueryable<BowlingInnings> innings)
    {
        return innings.Select(o => new BowlingInningsDto
        {
            Id = o.Id,
            Overs = o.Overs,
            Maidens = o.Maidens,
            Runs = o.Runs,
            Wickets = o.Wickets,
            Economy = o.Economy,
            Position = o.Position,
            Innings = o.Innings,
            Opposition = o.Opposition,
            TestNumber = o.TestNumber,
            Ground = o.Ground.Name,
            PlayerName = o.Player.Name
        });
    }
}