using System;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EF.Testing.UnitTests;

public class SqliteInMemoryBloggingControllerTest : IDisposable
{
    private readonly DbConnection _connection;
    private readonly DbContextOptions<CricketDataDb> _contextOptions;

    #region ConstructorAndDispose
    public SqliteInMemoryBloggingControllerTest()
    {
        // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
        // at the end of the test (see Dispose below).
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        // These options will be used by the context instances in this test suite, including the connection opened above.
        _contextOptions = new DbContextOptionsBuilder<CricketDataDb>()
            .UseSqlite(_connection)
            .Options;

        // Create the schema and seed some data
        using var context = new CricketDataDb(_contextOptions);

        context.Database.EnsureCreated();

        context.Add(
            new Ground
            {
                GroundId = 1,
                Name = "Trent Bridge",
                Country = "England",
                RecordCreated = DateTime.Now,
                RecordUpdated = DateTime.Now,
            }
        );

        context.SaveChanges();

        context.Add(
            new Player
            {
                PlayerId = 1,
                Name = "Richard Hadlee",
                CricInfoId = "6574",
                Team = "New Zealand",
                RecordCreated = DateTime.Now,
                RecordUpdated = DateTime.Now,
            }
        );

        context.SaveChanges();

        var player = context.Players.FirstOrDefault();

        var ground = context.Grounds.FirstOrDefault();

        context.AddRange(
            new BowlingInnings
            {
                Id = 1,
                Overs = 7,
                Maidens = 4,
                Runs = 8,
                Wickets = 7,
                Economy = 1.23f,
                Position = 1,
                Innings = 2,
                Opposition = "Kiwis",
                StartDate = new DateOnly(2020, 7, 2),
                TestNumber = null,
                RecordCreated = DateTime.Now,
                RecordUpdated = DateTime.Now,
                Player = player,
                Ground = ground,
                GroundName = ""
            },
            new BowlingInnings
            {
                Id = 2,
                Overs = 7,
                Maidens = 4,
                Runs = 8,
                Wickets = 7,
                Economy = 1.23f,
                Position = 1,
                Innings = 2,
                Opposition = "Kiwis",
                StartDate = new DateOnly(2020, 7, 2),
                TestNumber = null,
                RecordCreated = DateTime.Now,
                RecordUpdated = DateTime.Now,
                Player = player,
                Ground = ground,
                GroundName = ""
            }
        );
        context.SaveChanges();
    }

    CricketDataDb CreateContext() => new CricketDataDb(_contextOptions);

    public void Dispose() => _connection.Dispose();
    #endregion

    [Fact]
    public async Task GetBowlingInnings()
    {
        // Arrange
        using var context = CreateContext();
        var service = new BowlingInningsService(context);

        // Act
        var actual = await service.GetBowlingInningsAsync(1);

        // Assert
        Assert.IsAssignableFrom<IReadOnlyList<BowlingInningsDto>>(actual);

        Assert.Collection(
            actual,
            b => Assert.Equal(1, b.Id),
            b => Assert.Equal(2, b.Id));

        Assert.Collection(
            actual,
            b => Assert.Equal("Trent Bridge", b.Ground),
            b => Assert.Equal("Trent Bridge", b.Ground));

        Assert.Collection(
            actual,
            b => Assert.Equal("Richard Hadlee", b.PlayerName),
            b => Assert.Equal("Richard Hadlee", b.PlayerName));
    }
}