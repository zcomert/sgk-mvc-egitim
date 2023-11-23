using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, SqliteProductRepository>(); // register
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("sqliteconnection"),
        prj => prj.MigrationsAssembly("StoreApp")
    ));

var app = builder.Build();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute("default",
            "{controller=Home}/{action=Index}/{id?}");

app.Run();
