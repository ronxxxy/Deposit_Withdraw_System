using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NewPro.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(30); // Set the session timeout to 30 days
    options.Cookie.HttpOnly = true; // Security settings for the cookie
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

builder.Services.AddAuthentication("YourCookieAuthScheme")
    .AddCookie("YourCookieAuthScheme", options =>
    {
        options.LoginPath = "/User/Login"; // Redirect to login page if not authenticated
        options.LogoutPath = "/User/Logout"; // Redirect to logout action
        options.ExpireTimeSpan = TimeSpan.FromDays(30); // Set cookie expiration
    });

var conn = builder.Configuration.GetConnectionString("MySqlConn");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseSession();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
