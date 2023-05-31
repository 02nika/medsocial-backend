using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("UserStatuses", Schema = "backend")]
public class UserStatus
{
    public Enums.UserStatus Id { get; set; }
    
    [Required(ErrorMessage = "Name is required field")]
    [MaxLength(10, ErrorMessage = "Name length cannot be more than 10 characters")]
    public string Name { get; set; }
}