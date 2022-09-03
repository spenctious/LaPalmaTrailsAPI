using LaPalmaTrailsAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    string[] allowedOrigins =
    {
        // localhost with various ports for testing
        "http://127.0.0.1:5500",
        "http://127.0.0.1:5501",
        "http://127.0.0.1:5502",
        "http://127.0.0.1:5503",

        // live hosts
        "https://lapalmaforwalkers.netlify.app",
        "https://spenctious.github.io"
    };

    builder.WithOrigins(allowedOrigins)
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

// try to populate the URL lookup table from file but if that fails build it from an initial scrape
if (!StatusScraper.LoadUrlLookupTable())
{
    StatusScraper statusScraper = new();
    await statusScraper.GetTrailStatuses();
}

app.Run();

