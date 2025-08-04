using Equinox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Register EquinoxContext with SQLite DB
builder.Services.AddDbContext<EquinoxContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EquinoxConnection")));

// Add required services
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EquinoxContext>();
    context.Database.EnsureCreated();
}

// Middleware
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

// Routing for Admin Area
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

// Default Route for Main Site
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
