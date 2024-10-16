namespace AI.ProjectName.Http.Contracts;

/// <summary>
/// Aggregate.
/// </summary>
public class AggregateDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the Aggregate.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the Aggregate.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}