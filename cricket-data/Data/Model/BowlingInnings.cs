// using System.ComponentModel.DataAnnotations;

namespace cricket_data.data;

public class BowlingInnings
{
    public int Id { get; set; }

    public float Overs { get; set; }

    public int Maidens { get; set; }

    public int Runs { get; set; }

    public int Wickets { get; set; }

    public float Economy { get; set; }

    public int Position { get; set; }

    public int Innings { get; set; }

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

public class BowlingInningsDto
{
    public int Id { get; set; }

    public float Overs { get; set; }

    public int Maidens { get; set; }

    public int Runs { get; set; }

    public int Wickets { get; set; }

    public float Economy { get; set; }

    public int Position { get; set; }

    public int Innings { get; set; }

    public string Opposition { get; set; }

    public string? TestNumber { get; set; }

    public string? Ground { get; set; }

    public string? PlayerName { get; set; }

    // public BowlingInningsDto() { }
    // public BowlingInningsDto(BowlingInnings inns) =>
    // (Id, Overs, Maidens, Runs, Wickets, Economy, Position, Innings, Opposition, TestNumber, Ground, PlayerName) =

    // (inns.Id, inns.Overs, inns.Maidens, inns.Runs, inns.Wickets, inns.Economy,
    // inns.Position, inns.Innings, inns.Opposition, inns.TestNumber, inns.Ground?.Name, inns.Player?.Name);
}