using DinasPendidikan.Database;
using DinasPendidikan.Database.Repositories.Documents;
using DinasPendidikanDokumenService.Services.SuratKeluarServices;
using DinasPendidikanDokumenService.Services.SuratMasukServices;
using Microsoft.EntityFrameworkCore; // Add this using directive for UseNpgsql extension method

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

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
