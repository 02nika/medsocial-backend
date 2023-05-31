using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos;

public class UserLoginDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    [Required]
    [MinLength(7, ErrorMessage = "Password Must be 7 symbols at least.")]
    public string Password { get; set; }
}