using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts;


public interface IAuthService
{
    IEnumerable<IdentityRole> GetAllRoles();
    IEnumerable<IdentityUser> GetAllUsers();
    Task<IdentityResult> CreateOneUser(UserDtoForCreation userDto);
    Task<IdentityResult> AddRoles(IdentityUser user, HashSet<String> roles);

}