using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Users", Schema = "backend")]
public class User : BaseEntity
{
    [ForeignKey(nameof(UserStatus))]
    public Enums.UserStatus Status { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserStatus UserStatus { get; set; }
}