using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Portfolio.Pages.HookOrBeHooked;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


// Configure Kestrel with settings from appsettings.json or appsettings.Development.json
builder.WebHost.ConfigureKestrel((context, options) =>
{
    var kestrelSection = context.Configuration.GetSection("Kestrel");
    options.Configure(kestrelSection);
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 11, 3)) // Specify MariaDB version here
    )
);

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://moon-pi.net", "https://localhost")  // Add localhost for development
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();  // Allow SignalR to use credentials
    });
});

// Add SignalR service
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map the SignalR Hub endpoint
app.MapHub<GameHub>("/gameHub");

app.Run();