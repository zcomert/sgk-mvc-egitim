using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services;

public class AuthService : IAuthService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthService(RoleManager<IdentityRole> roleManager, 
        UserManager<IdentityUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public IEnumerable<IdentityRole> GetAllRoles()
    {
        return _roleManager.Roles;
    }

    public IEnumerable<IdentityUser> GetAllUsers()
    {
        return _userManager.Users;
    }
}