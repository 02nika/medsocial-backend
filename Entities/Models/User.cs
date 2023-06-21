using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Users", Schema = "backend")]
public class User : BaseEntity
{
    [ForeignKey(nameof(UserStatus))] 
    public Enums.UserStatus Status { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    [ForeignKey(nameof(_Gender))] 
    public Enums.Gender Gender { get; set; }
    
    public string Email { get; set; }

    [ForeignKey(nameof(Country))] 
    public Guid? CountryId { get; set; }
    
    [ForeignKey(nameof(City))] 
    public Guid CityId { get; set; }

    [ForeignKey(nameof(Timezone))]
    public Guid TimezoneId { get; set; }
    
    [ForeignKey(nameof(_Language))]
    public Enums.Language Language { get; set; }
    
    public string Password { get; set; }

    public bool IsRegistered { get; set; }

    public UserStatus? UserStatus { get; set; }
    public Gender _Gender { get; set; }
    public Country? Country { get; set; }
    public City? City { get; set; }
    public Timezone? Timezone { get; set; }
    public Language _Language { get; set; }
}