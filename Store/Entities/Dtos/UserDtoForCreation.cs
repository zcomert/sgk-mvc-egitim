
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record UserDtoForCreation
{
    [DataType(DataType.Text)]
    [Required(ErrorMessage ="Zorunlu alan.")]
    public String UserName { get; init; }
    
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage ="Zorunlu alan.")]
    public String Email { get; init; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage ="Zorunlu alan.")]
    public String Password { get; init; }

    public HashSet<String> Roles { get; init; }
}