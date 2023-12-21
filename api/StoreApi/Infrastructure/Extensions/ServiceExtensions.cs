﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
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
                .HasApiVersion(new ApiVersion(1, 0));
        });
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
    }
}
