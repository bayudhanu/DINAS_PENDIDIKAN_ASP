using DinasPendidikan.Database;
using DinasPendidikan.Database.Repositories.Documents;
using DinasPendidikan.DokumenService.Services.SuratKeluarServices;
using DinasPendidikan.DokumenService.Services.SuratMasukServices;
using Microsoft.EntityFrameworkCore;
using DinasPendidikan.Contracts;
using RabbitMQ.Client; // Add this using directive for UseNpgsql extension method

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

// Add services
// builder.Services.AddSingleton<IConnection>(_ => {
//     var factory = new ConnectionFactory { HostName = "localhost" };
//     return factory.CreateConnection();
// });
// builder.Services.AddSingleton<IModel>(serviceProvider =>
// {
//     var connection = serviceProvider.GetRequiredService<IConnection>();
//     return connection.CreateModel();
// });

builder.Services.AddControllers();

builder.Services.AddDbContext<DinasPendidikanDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ensure the Microsoft.EntityFrameworkCore.PostgreSQL package is installed

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// repository
builder.Services.AddScoped<ISuratKeluarRepository, SuratKeluarRepository>();
builder.Services.AddScoped<ISuratMasukRepository, SuratMasukRepository>();
builder.Services.AddScoped<IDisposisiRepository, DisposisiRepository>();

// services
builder.Services.AddScoped<ISuratKeluarService, SuratKeluarService>();
builder.Services.AddScoped<ISuratMasukService, SuratMasukService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure RabbitMQ exchanges
// using (var scope = app.Services.CreateScope())
// {
//     var channel = scope.ServiceProvider.GetRequiredService<IModel>();
//     channel.ExchangeDeclare("suratmasuk.import", ExchangeType.Fanout, durable: true);
//     channel.ExchangeDeclare("suratmasuk.status", ExchangeType.Fanout, durable: true);
// }
app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

await app.RunAsync();
