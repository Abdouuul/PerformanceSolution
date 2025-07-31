using Performance.Lib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

PerformanceService service = new();

var dataset = new[]
            {
                Tuple.Create(new DateTime(2021, 1, 1), 180.0),
                Tuple.Create(new DateTime(2021, 6, 1), 200.0),
                Tuple.Create(new DateTime(2021, 12, 31), 250.0),
            };

app.MapGet("/performance", (
    DateTime from,
    DateTime to
) =>
{
    try
    {
        var performance = service.GetPerformance(dataset, from, to);
        var response = new ApiResponse(performance);
        return Results.Ok(response);
    }
    catch (System.Exception e)
    {
        return Results.BadRequest(new {error=e.Message});
    }
})
.WithName("GetPerformance");

app.Run();

record ApiResponse(double Performance);
