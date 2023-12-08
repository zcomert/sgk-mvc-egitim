using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services;

public class AuthService : IAuthService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public IEnumerable<IdentityRole> GetAllRoles()
    {
        return _roleManager.Roles;
    }
}