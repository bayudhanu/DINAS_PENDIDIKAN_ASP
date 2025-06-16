using DinasPendidikan.Database;
using DinasPendidikan.Database.Repositories.Documents;
using Microsoft.EntityFrameworkCore; // Add this using directive for UseNpgsql extension method
using DinasPendidikan.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);
var hostApplicationBuilder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DinasPendidikanDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ensure the Microsoft.EntityFrameworkCore.PostgreSQL package is installed

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services
builder.Services.AddSingleton<IConnection>(_ => {
    var factory = new ConnectionFactory { HostName = "localhost" };
    return factory.CreateConnection();
});
builder.Services.AddSingleton<IModel>(serviceProvider => {
    var connection = serviceProvider.GetRequiredService<IConnection>();
    return connection.CreateModel();
});
builder.Services.AddHostedService<SuratMasukProcessor>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

var host = hostApplicationBuilder.Build();
host.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
