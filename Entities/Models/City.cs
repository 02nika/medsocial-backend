using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Cities", Schema = "backend")]
public class City : BaseEntity
{
    [Required]
    public string Name { get; set; }
 
    [ForeignKey(nameof(Country))]
    public Guid CountyId { get; set; }
    
    public Country Country { get; set; }
}