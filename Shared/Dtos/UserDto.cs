using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.Dtos;

public class UserDto
{
    public UserStatusDtoEnum Status { get; set; }

    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public GenderDto Gender { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    [Required]
    public Guid CountryId { get; set; }
    
    [Required]
    public Guid CityId { get; set; }
    
    [Required]
    public Guid TimezoneId { get; set; }
    
    public LanguageDto Language { get; set; }
    
    [Required]
    [MinLength(7, ErrorMessage = "Password Must be 7 symbols at least.")]
    public string Password { get; set; }
}