using Microsoft.AspNetCore.Http.HttpResults;

namespace cricket_data.tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.True(true);
    }

    // change test name
    [Fact]
    public async Task GetBowlingInningsReturnsNotFoundIfNotExists()
    {
        // Arrange
        var mock = new Mock<IBowlingInningsService>();

        mock.Setup(m => m.GetBowlingInningsAsync(It.IsAny<int>())) //It.Is<int>(id => id == 1)))
            .ReturnsAsync(new List<BowlingInningsDto>());

        // Act
        var result = await BowlingInningsEnpoints.GetBowlingInnings(1, mock.Object);

        // Assert: Check for the correct returned type
        Assert.IsType<NotFound>(result);
        // Assert.IsType<Ok<Todo[]>>(result);
    }

    //     [Fact]
    // public async Task GetBowlingInningsReturns_____________________NotFoundIfNotExists()
    // {
    //     // Arrange
    //     var mock = new Mock<IBowlingInningsService>();

    //     mock.Setup(m => m.GetBowlingInningsAsync(It.IsAny<int>())) //It.Is<int>(id => id == 1)))
    //             .ThrowsAsync(new InvalidOperationException());

    //     // Act
    //     var result = await BowlingInningsEnpoints.GetBowlingInnings(1, mock.Object);

    //     // Assert: Check for the correct returned type
    //     Assert.IsType<ProblemDetails>(result);
    //     // Assert.IsType<Ok<Todo[]>>(result);
    // }

    [Fact]
    public async Task GetBowlingInningsReturnsOkOfBowlingInningsDto()
    {
        // Arrange
        var mock = new Mock<IBowlingInningsService>();

        mock.Setup(m => m.GetBowlingInningsAsync(It.IsAny<int>())) //It.Is<int>(id => id == 1)))
            .ReturnsAsync(new List<BowlingInningsDto> {
                new BowlingInningsDto
                {
                    Id = 1,
                    Overs = 7,
                    Maidens = 4,
                    Runs = 8,
                    Wickets =7,
                    Economy = 1.23f,
                    Position = 1,
                    Innings = 2,
                    Opposition = "Kiwis",
                    Ground = "Old T",
                    PlayerName = "W G Grace"
                }
            });

        // Act
        var result = await BowlingInningsEnpoints.GetBowlingInnings(1, mock.Object);

        // Assert: Check for the correct returned type
        Assert.IsType<Ok<IReadOnlyList<BowlingInningsDto>>>(result);
    }

    // public async Task GetAllTodos_ReturnsOkOfTodosResult()
    // {
    //     // Arrange
    //     var db = CreateDbContext();

    //     // Act
    //     var result = await TodosApi.GetAllTodos(db);

    //     // Assert: Check for the correct returned type
    //     Assert.IsType<Ok<Todo[]>>(result);
    // }
}