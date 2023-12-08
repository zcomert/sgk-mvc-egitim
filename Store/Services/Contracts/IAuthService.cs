using Microsoft.AspNetCore.Identity;

namespace Services.Contracts;


public interface IAuthService
{
    IEnumerable<IdentityRole> GetAllRoles();
    IEnumerable<IdentityUser> GetAllUsers();
}