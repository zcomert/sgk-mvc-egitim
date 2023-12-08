using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services;

public class AuthService : IAuthService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;

    public AuthService(RoleManager<IdentityRole> roleManager,
        UserManager<IdentityUser> userManager,
        IMapper mapper)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<IdentityResult> AddRoles(IdentityUser user, 
        HashSet<string> roles)
    {
        return await _userManager.AddToRolesAsync(user, roles);
    }

    public async Task<IdentityResult> CreateOneUser(UserDtoForCreation userDto)
    {
        var user = _mapper.Map<IdentityUser>(userDto);
        var result = 
            await _userManager.CreateAsync(user,userDto.Password);

        if (!result.Succeeded)
            throw new Exception();

        var roleResult = await AddRoles(user, userDto.Roles);
        
        if (!roleResult.Succeeded)
            throw new Exception();
        
        return roleResult;
    }

    public IEnumerable<IdentityRole> GetAllRoles()
    {
        return _roleManager.Roles;
    }

    public IEnumerable<IdentityUser> GetAllUsers()
    {
        return _userManager.Users;
    }

    public async Task<IdentityUser> GetOneUser(string userName)
    {
        var user = await _userManager
            .FindByNameAsync(userName);
        return user;
    }
}