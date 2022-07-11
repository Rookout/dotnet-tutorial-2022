using Rook;

Rook.RookOptions options = new Rook.RookOptions()
{
    token = "XXXXXXXXXXXXXXXX",
    labels = new Dictionary<string, string> { { "env", "dev" } }
};
Rook.API.Start(options);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();

