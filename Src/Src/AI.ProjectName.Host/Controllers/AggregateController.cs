using AI.ProjectName.Aggregate;
using AI.ProjectName.Http.Contracts;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace AI.ProjectName.Host.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
internal class AggregateController(AggregateHandler aggregateHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAggregate([FromBody] CreateAggregateCommand command, CancellationToken cancellationToken)
    {
        var aggregateId = await aggregateHandler.CreateAggregate(command, cancellationToken);
        return CreatedAtAction(nameof(GetAggregate), new { id = aggregateId }, aggregateId);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<AggregateDto>> GetAggregate(long id, CancellationToken cancellationToken)
    {
        var aggregate = await aggregateHandler.GetAggregate(id, cancellationToken);
        return Ok(aggregate);
    }
}