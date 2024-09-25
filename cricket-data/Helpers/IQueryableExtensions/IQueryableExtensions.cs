namespace cricket_data.helpers;

public static class QueryableExtensions
{
    public static IQueryable<BowlingInningsDto> MapBowlingInningsModelToDto(this IQueryable<BowlingInnings> innings)
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
            Ground = o.Ground.Name,
            PlayerName = o.Player.Name
        });
    }
}