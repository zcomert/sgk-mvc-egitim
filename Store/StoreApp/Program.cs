using Entities.Models;
using Repositories;
using Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductRepository, DynamicProductRepository>(); // register

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute("default",
            "{controller=Home}/{action=Index}/{id?}");

app.Run();
