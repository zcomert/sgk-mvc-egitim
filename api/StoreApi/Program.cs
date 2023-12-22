using Microsoft.EntityFrameworkCore;
using Repositories;
using StoreApi.Infrastructure.Extensions;
using StoreApi.InMemoryRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true; //406
    })
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<BookRepositoryFake>();



builder.Services.ConfigureVersioning();
builder.Services.ConfigureRepositories(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.ConfigureCORS();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseCors("Default");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.ConfigureExceptionHandler();
app.Run();
