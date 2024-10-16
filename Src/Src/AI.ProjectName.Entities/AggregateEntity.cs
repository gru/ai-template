using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AI.ProjectName.Entities;

[Table("aggregates")]
public class AggregateEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id", TypeName = "bigint")]
    public long Id { get; set; }

    [Required]
    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;
}