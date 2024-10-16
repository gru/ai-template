using AI.ProjectName.Entities;
using AI.ProjectName.Http.Contracts;
using FluentValidation;

namespace AI.ProjectName.Aggregate;

/// <summary>
/// Handles business logic operations related to Aggregates.
/// This class is responsible for creating and retrieving Aggregate entities.
/// </summary>
public class AggregateHandler
{
    private readonly ProjectDbContext _dbContext;
    private readonly IValidator<CreateAggregateCommand> _validator;

    /// <summary>
    /// Initializes a new instance of the AggregateHandler class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing Aggregate entities.</param>
    /// <param name="validator">The validator for CreateAggregateCommand.</param>
    public AggregateHandler(ProjectDbContext dbContext, IValidator<CreateAggregateCommand> validator)
    {
        _dbContext = dbContext;
        _validator = validator;
    }

    /// <summary>
    /// Creates a new Aggregate entity based on the provided command.
    /// </summary>
    /// <param name="command">The command containing details for creating the Aggregate.</param>
    /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
    /// <returns>The ID of the newly created Aggregate.</returns>
    /// <exception cref="ValidationException">Thrown when the command fails validation.</exception>
    public async Task<long> CreateAggregate(CreateAggregateCommand command, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(command, cancellationToken);

        var aggregate = new AggregateEntity
        {
            Name = command.Name
        };

        _dbContext.Aggregates.Add(aggregate);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return aggregate.Id;
    }

    /// <summary>
    /// Retrieves an Aggregate entity by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the Aggregate to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
    /// <returns>The retrieved AggregateEntity.</returns>
    /// <exception cref="InvalidOperationException">Thrown when an Aggregate with the specified ID is not found.</exception>
    public async Task<AggregateEntity> GetAggregate(long id, CancellationToken cancellationToken)
    {
        var aggregate = await _dbContext.Aggregates.FindAsync([id], cancellationToken);
            
        if (aggregate == null)
        {
            throw new InvalidOperationException($"Aggregate with id {id} not found");
        }

        return aggregate;
    }
}