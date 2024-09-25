// using System.ComponentModel.DataAnnotations;

namespace cricket_data.data;

public class BowlingInnings
{
    public int Id { get; set; }

    public float? Overs { get; set; }

    public int? Maidens { get; set; }

    public int? Runs { get; set; }

    public int? Wickets { get; set; }

    public float? Economy { get; set; }

    public int? Position { get; set; }

    public int? Innings { get; set; }

    public string Opposition { get; set; }

    public string GroundName { get; set; }  // Ground string from the data source

    public DateOnly StartDate { get; set; }

    public string? TestNumber { get; set; }

    public DateTime RecordCreated { get; set; }

    public DateTime RecordUpdated { get; set; }

    public int? GroundId { get; set; }
    public Ground? Ground { get; set; }

    public int? PlayerId { get; set; } // foreign key property
    public Player? Player { get; set; } // reference navigation to principal
}

public record BowlingInningsDto
{
    public int Id { get; init; }

    public float? Overs { get; init; }

    public int? Maidens { get; init; }

    public int? Runs { get; init; }

    public int? Wickets { get; init; }

    public float? Economy { get; init; }

    public int? Position { get; init; }

    public int? Innings { get; init; }

    public string Opposition { get; init; }

    public string? Ground { get; init; }

    public string? PlayerName { get; init; }
}