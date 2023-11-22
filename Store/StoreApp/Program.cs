using Entities.Models;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ProductRepository>(); // register

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute("default",
            "{controller=Home}/{action=Index}/{id?}");

app.Run();
