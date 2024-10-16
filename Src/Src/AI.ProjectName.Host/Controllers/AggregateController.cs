using AI.ProjectName.Aggregate;
using AI.ProjectName.Http.Contracts;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace AI.ProjectName.Host.Controllers;

/// <summary>
/// Controller responsible for handling Aggregate-related HTTP requests.
/// This controller is versioned and mapped to the route "api/v{version:apiVersion}/[controller]".
/// </summary>
[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
internal class AggregateController : ControllerBase
{
    private readonly AggregateHandler _aggregateHandler;

    /// <summary>
    /// Initializes a new instance of the AggregateController class.
    /// </summary>
    /// <param name="aggregateHandler">The handler for aggregate-related operations.</param>
    public AggregateController(AggregateHandler aggregateHandler)
    {
        _aggregateHandler = aggregateHandler;
    }

    /// <summary>
    /// Creates a new Aggregate.
    /// </summary>
    /// <param name="command">The command containing the details for creating the Aggregate.</param>
    /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
    /// <returns>An ActionResult containing the ID of the newly created Aggregate.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAggregate([FromBody] CreateAggregateCommand command, CancellationToken cancellationToken)
    {
        var aggregateId = await _aggregateHandler.CreateAggregate(command, cancellationToken);
        return CreatedAtAction(nameof(GetAggregate), new { id = aggregateId }, aggregateId);
    }

    /// <summary>
    /// Retrieves an Aggregate by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the Aggregate to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
    /// <returns>An ActionResult containing the AggregateDto of the requested Aggregate.</returns>
    [HttpGet("{id:long}")]
    public async Task<ActionResult<AggregateDto>> GetAggregate(long id, CancellationToken cancellationToken)
    {
        var aggregate = await _aggregateHandler.GetAggregate(id, cancellationToken);
        return Ok(aggregate);
    }
}