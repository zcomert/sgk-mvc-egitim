using Entities.Models;
using StoreApp.Infrastructure.Extensions;
using StoreApp.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureRepositories(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureSession();
builder.Services.ConfigureIdentity();

builder.Services.AddScoped<Cart>(
    c => SessionCart.GetCard(c));


var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    endpoints.MapRazorPages();


    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();
