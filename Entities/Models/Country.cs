using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Countries", Schema = "backend")]
public class Country : BaseEntity
{
    [Required(ErrorMessage = "Name is required field")]
    [MaxLength(50, ErrorMessage = "Name length cannot be more than 16 characters")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Country Code is required field")]
    [Column(TypeName = "char(2)")]
    public string CountryCode { get; set; }
}
