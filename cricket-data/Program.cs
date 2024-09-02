using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CricketDataDb>(opt => opt.UseInMemoryDatabase("CricketData"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "CricketDataAPI";
    config.Title = "CricketDataAPI v1";
    config.Version = "v1";
});

builder.Services.AddScoped<IBowlingInningsService, BowlingInningsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "CricketDataAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapGet("/", () => "Hello World!");

var bowlingInnings = app.MapGroup("/bowling-innings"); // MapGroup API

bowlingInnings.MapGet("/", BowlingInningsEnpoints.GetAllBowlingInnings);
bowlingInnings.MapGet("/player/{id}", BowlingInningsEnpoints.GetBowlingInnings);

app.Run();