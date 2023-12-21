using Entities;
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
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError; // 500
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Birşeyler ters gitti ;("
                    }.ToString());
                }
            });
        });
    }
}