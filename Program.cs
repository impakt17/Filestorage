using Microsoft.EntityFrameworkCore;
using FileStorageApi.Data; // Anpassa till rätt namespace för din AppDbContext
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Lägger till controllers
builder.Services.AddControllers();

// Swagger (API-dokumentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Lägger till databas (PostgreSQL + Entity Framework)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger i utvecklingsläge
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
     app.UseSwaggerUI();
}

 // app.UseHttpsRedirection();

app.UseAuthorization();

// Länk till controllers
app.MapControllers();

app.Run();

