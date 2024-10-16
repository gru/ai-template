using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AI.ProjectName.Entities;

/// <summary>
/// Represents an Aggregate entity in the database.
/// This class defines the structure and properties of the Aggregate table.
/// </summary>
[Table("aggregates")]
public class AggregateEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the Aggregate.
    /// This is the primary key of the table.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id", TypeName = "bigint")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the Aggregate.
    /// This field is required and stored as text in the database.
    /// </summary>
    [Required]
    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;
}