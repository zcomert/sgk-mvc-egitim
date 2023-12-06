using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

namespace StoreApp.Infrastructure.Extensions;

public static class ServiceExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services">Bu parametre metot çağırsı yapılırken kullanılmaz!</param>
    public static void ConfigureRepositories(this IServiceCollection services,
        IConfiguration configuration)
    {
        // register
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        // repository
        services.AddDbContext<RepositoryContext>(options =>
        {
            options
                .UseSqlite(configuration
                .GetConnectionString("sqliteconnection"),
                prj => prj.MigrationsAssembly("StoreApp"));
        });

        
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>(); // register
        services.AddScoped<ICategoryService, CategoryService>(); // register
        services.AddScoped<IProductService, ProductService>(); // register
    }

}