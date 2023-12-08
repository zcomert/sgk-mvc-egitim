using System.Data;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace StoreApp.Infrastructure.Extensions;

public static class WebApplicationExtension
{
    public static async void UseDefaultAdmin(this IApplicationBuilder app)
    {
        const string userName = "Admin";
        const string email = "admin@sgk.gov.tr";
        const string password = "P@ssw0rd!";

        var _manager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<IServiceManager>();


        var adminUser = await _manager.AuthService.GetOneUser("Admin");

        if (adminUser is null)
        {
            var result = await _manager.AuthService.CreateOneUser(
            new UserDtoForCreation()
            {
                UserName = userName,
                Email = email,
                Password = password,
                Roles = new HashSet<String>() { "Admin", "Editor", "User" }
            });
            if (!result.Succeeded)
                throw new Exception("Default admin has problem.");
        }
    }
}