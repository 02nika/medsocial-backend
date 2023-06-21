using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Genders", Schema = "backend")]
public class Gender
{
    public Enums.Gender Id { get; set; }
    
    [Required(ErrorMessage = "Name is required field")]
    [MaxLength(10, ErrorMessage = "Name length cannot be more than 10 characters")]
    public string Name { get; set; }
}