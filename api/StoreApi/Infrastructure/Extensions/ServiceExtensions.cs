using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Presentation.Controllers;
using Repositories;
using Repositories.Contracts;

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
                .HasApiVersion(new ApiVersion(2, 0));
        });
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
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

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v2", new OpenApiInfo { Title = "SGK", Version = "v2" });
        });
    }
}
