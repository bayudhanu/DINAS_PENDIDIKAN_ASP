using Aspire.Hosting;
using System.Text;
using DinasPendidikan.Database;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container  
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DinasPendidikan API", Version = "v1" });
});

// Database context  
builder.Services.AddDbContext<DinasPendidikanDbContext>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ensure 'Microsoft.EntityFrameworkCore.Npgsql' package is installed

// Authentication  
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = builder.Configuration["Jwt:Issuer"],
           ValidAudience = builder.Configuration["Jwt:Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
       };
   });

var app = builder.Build();

// Add the missing extension method implementation
app.UseServiceDefaults();

// Configure the HTTP request pipeline  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();