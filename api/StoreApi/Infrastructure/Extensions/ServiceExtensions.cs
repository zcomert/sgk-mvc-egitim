using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Presentation.Controllers;
using Repositories;
using Repositories.Contracts;
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
                .HasApiVersion(new ApiVersion(3, 0));
        });
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();
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
