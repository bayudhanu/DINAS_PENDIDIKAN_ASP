using DocumentManagementSystem;
using DocumentManagementSystem.Components;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.Repositories;
using DocumentManagementSystem.Services;
using Microsoft.AspNetCore.Identity; // Add this namespace
using Microsoft.AspNetCore.Identity.UI; // Add this namespace if needed
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
// Configure Entity Framework Core with SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Configure Identity services
builder.Services.AddIdentity<User, IdentityRole>(options => // Replace AddDefaultIdentity with AddIdentity
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



// Register the repository for dependency injection
builder.Services.AddScoped<ISuratMasukRepository, SuratMasukRepository>();

// Register the service for dependency injection
builder.Services.AddScoped<ISuratMasukService, SuratMasukService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

// Configure Identity options
var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/vendors"))
    {
        var filePath = Path.Combine(builder.Environment.WebRootPath,
            context.Request.Path.Value.TrimStart('/'));
        Console.WriteLine($"Request: {context.Request.Path}");
        Console.WriteLine($"Physical path: {filePath}");
        Console.WriteLine($"Exists: {File.Exists(filePath)}");
    }
    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Detail error lebih lengkap
    app.UseDeveloperExceptionPage();

    // Serve node_modules jika diperlukan (untuk development)
    var nodeModulesPath = Path.Combine(builder.Environment.ContentRootPath, "node_modules");
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(nodeModulesPath),
        RequestPath = "/node_modules"
    });

    // Matikan caching di development
    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers["Cache-Control"] = "no-store, no-cache";
        }
    });

    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    // Optional: Atur cache header untuk static files
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
    },
    // Optional: Serve unknown file types (default false)
    ServeUnknownFileTypes = false,
    // Optional: Default MIME type jika tidak dikenali
    DefaultContentType = "application/octet-stream"
});

app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();
