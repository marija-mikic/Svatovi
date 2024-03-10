using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Svatovi.Areas.Identity.Data;
using Svatovi.Models;
using Svatovi.Repository;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SvatoviContextConnection") ?? throw new InvalidOperationException("Connection string 'SvatoviContextConnection' not found.");

builder.Services.AddDbContext<SvatoviContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IImageRepository, ImageRepository>();
   
//builder.Services.AddDefaultIdentity<SvatoviUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SvatoviContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
