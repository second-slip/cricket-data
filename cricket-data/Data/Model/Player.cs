namespace cricket_data.data;

public class Player
{
    public int PlayerId { get; set; }

    public string CricInfoId { get; set; }

    public string Name { get; set; }

    public string Team { get; set; }

    public DateTime RecordCreated { get; set; }

    public DateTime RecordUpdated { get; set; }

    public ICollection<BowlingInnings> BowlerInnings { get; } = new List<BowlingInnings>(); // Collection navigation containing dependents
}