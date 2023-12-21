using Entities;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace StoreApi.Infrastructure.Extensions;

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature is not null) // hata var demek
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundExceptions => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }
}