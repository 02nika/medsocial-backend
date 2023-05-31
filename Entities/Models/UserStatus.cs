using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("UserStatuses", Schema = "backend")]
public class UserStatus
{
    public Enums.UserStatus Id { get; set; }
    
    [Required(ErrorMessage = "State is required field")]
    [MaxLength(10, ErrorMessage = "State length cannot be more than 10 characters")]
    public string Name { get; set; }
}