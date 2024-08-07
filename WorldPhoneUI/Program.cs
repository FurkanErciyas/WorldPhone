using BLL.Interfaces;
using BLL.Services;
using DAL.Context;
using ENTITIES.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using WorldPhone.DAL.Context;
using WorldPhone.ENTITIES.Models;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("tr-TR");
cultureInfo.NumberFormat.CurrencySymbol = "?";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var connectionString = builder.Configuration.GetConnectionString("WorldPhoneDbContextConnection") ?? throw new InvalidOperationException("Connection string 'WorldPhoneDbContextConnection' not found.");

builder.Services.AddDbContext<WorldPhoneDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<WorldPhoneDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPhoneService, PhoneService>();

builder.Services.AddAutoMapper(typeof(PhoneProfile));
builder.Services.AddAutoMapper(typeof(BrandProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    name: "Customer",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<WorldPhoneDbContext>();
    WorldPhoneDbContextSeed.Seed(dbContext);
    await WorldPhoneDbContextSeed.SeedUserAsync(roleManager, userManager);
}

app.MapRazorPages();

app.Run();
