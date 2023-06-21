using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Timezones", Schema = "backend")]
public class Timezone : BaseEntity
{
    public string Name { get; set; }
}