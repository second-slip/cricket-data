namespace cricket_data.data;
public class Ground
{
    public int GroundId { get; set; }

    public string Name { get; set; }

    public string Country { get; set; }

    public DateTime RecordCreated { get; set; }

    public DateTime RecordUpdated { get; set; }

    public ICollection<BowlingInnings> BowlerInnings { get; } = new List<BowlingInnings>();
}