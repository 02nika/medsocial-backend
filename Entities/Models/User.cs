using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Users", Schema = "backend")]
public class User : BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
}