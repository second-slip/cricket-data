using Microsoft.EntityFrameworkCore;

namespace cricket_data.endpoints;

public static class BowlingInningsEnpoints
{
    public static async Task<IResult> GetBowlingInnings(int id, IBowlingInningsService service)
    {
        var result = await service.GetBowlingInningsAsync(id);

        return result.Any()
            ? TypedResults.Ok(result)
            : TypedResults.NotFound();
    }
}