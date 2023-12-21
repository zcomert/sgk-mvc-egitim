# Eklenti (Extension) metot
1. Eklenti metotlar static sınıflara yazılır.
2. Static sınıfların tüm üyeleri static olur.
3. Genişletilecek tip this ile belirtilir. 
4. this ve Type ifadesi ilk parametre olarak kullanılır. 
5. Eklenti metot çağrılarılırken this ifadesindeki parametre görmezden gelinir. 

```csharp
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

                if(contextFeature is not null) // hata var demek
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError; // 500
                    await context.Response.WriteAsync("Bir �eyler ters gitti.");
                }
            });
        });
    }
}
```