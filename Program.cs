using Microsoft.EntityFrameworkCore;
using PersonalRecords.Data;
using DotNetEnv;
using OfficeOpenXml;
using Microsoft.AspNetCore.Authentication.Cookies;

var modelBuilder = WebApplication.CreateBuilder(args);

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
DotNetEnv.Env.Load();
modelBuilder.Configuration.AddEnvironmentVariables();

// Add services to the container.
modelBuilder.Services.AddControllersWithViews();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";
modelBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

modelBuilder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });

modelBuilder.Services.AddAuthorization();

var app = modelBuilder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
