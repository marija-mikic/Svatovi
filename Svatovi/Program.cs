using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Svatovi.Areas.Identity.Data;
using Svatovi.Models;
using Svatovi.Repository;
using Microsoft.Extensions.Azure;
using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"] /*?? throw new InvalidOperationException("'ConnectionStrings'  not found.")*/;

builder.Services.AddDbContext<SvatoviContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IImageRepository, ImageRepository>();

//builder.Services.AddDefaultIdentity<SvatoviUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SvatoviContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddAzureClients(clientBuilder =>
//{
//    clientBuilder.AddBlobServiceClient(builder.Configuration["ConnectionStrings:sqlserver-svatovi-001:blob"]!, preferMsi: true);
//    clientBuilder.AddQueueServiceClient(builder.Configuration["ConnectionStrings:sqlserver-svatovi-001:queue"]!, preferMsi: true);
//});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//})
//.AddCookie(options =>
//{
//    options.LoginPath = "/Admin/DobroDosli";
//    options.AccessDeniedPath = "/Account/AccessDenied";
//});


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
    pattern: "{controller=Home}/{action=Index}");

app.Run();