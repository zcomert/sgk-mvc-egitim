using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Presentation.Controllers;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StoreApi.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);

            options.ApiVersionReader =
                new HeaderApiVersionReader("api-version");

            options.Conventions.Controller<BooksController>()
                .HasDeprecatedApiVersion(new ApiVersion(1, 0));

            options.Conventions.Controller<BooksV2Controller>()
                .HasDeprecatedApiVersion(new ApiVersion(2, 0));

            options.Conventions.Controller<BooksV3Controller>()
                .HasDeprecatedApiVersion(new ApiVersion(3, 0));

            options.Conventions.Controller<BooksV4Controller>()
               .HasApiVersion(new ApiVersion(4, 0));
        });
    }

    public static void ConfigureRepositories(this IServiceCollection services, IConfiguration config)
    {

        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseSqlServer(
            config.GetConnectionString("sqlconnection"),
            prj => prj.MigrationsAssembly("StoreApi"));
        });

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookManager>();
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    public static void ConfigureCORS(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Default", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });
    }






}
