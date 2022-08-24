
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MagicDishWebApplication.Data;
using MagicDishWebApplication.Models;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using MagicDishWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MagicDishWebApplicationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IEmailSender>(ServiceProvider => new EmailSender("localhost", 25, "no-reply@magicdish.com"));



builder.Services.AddDefaultIdentity<MagicDishWebApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MagicDishWebApplicationContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();





//builder.Services.AddRazorPages();                   potrzebne?

//builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews(view => view.Filters.Add(new AuthorizeFilter()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
