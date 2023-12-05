using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, ProductRepository>(); // register
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // register
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>(); // register

builder.Services.AddScoped<IServiceManager, ServiceManager>(); // register
builder.Services.AddScoped<ICategoryService, CategoryService>(); // register
builder.Services.AddScoped<IProductService, ProductService>(); // register


builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("sqliteconnection"),
        prj => prj.MigrationsAssembly("StoreApp")
    ));

var app = builder.Build();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );


    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();
