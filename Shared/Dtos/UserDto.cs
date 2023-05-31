using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.Dtos;

public class UserDto
{
    public UserStatusDtoEnum Status { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    [Required]
    [MinLength(7, ErrorMessage = "Password Must be 7 symbols at least.")]
    public string Password { get; set; }
}