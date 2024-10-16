using RestEase;

namespace AI.ProjectName.Http.Contracts;

/// <summary>
/// Represents the contract for the Aggregate API (version 1).
/// This interface defines the operations available for interacting with Aggregate resources.
/// It is designed to be used with RestEase for generating API clients.
/// </summary>
[Header("Accept", "application/json")]
public interface IAggregateV1Controller
{
    /// <summary>
    /// Creates a new Aggregate.
    /// </summary>
    /// <param name="command">The command containing the details for creating the Aggregate.</param>
    /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
    /// <returns>The ID of the newly created Aggregate.</returns>
    [Post("api/v1/Aggregate")]
    Task<long> CreateAggregate([Body] CreateAggregateCommand command, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an Aggregate by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the Aggregate to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
    /// <returns>The Aggregate DTO containing the details of the requested Aggregate.</returns>
    [Get("api/v1/Aggregate/{id}")]
    Task<AggregateDto> GetAggregate([Path] long id, CancellationToken cancellationToken = default);
}