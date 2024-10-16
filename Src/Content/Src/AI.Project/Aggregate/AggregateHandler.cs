using AI.Project.Entities;
using AI.Project.Http.Contracts;
using FluentValidation;

namespace AI.Project.Aggregate;

internal class AggregateHandler(ProjectDbContext dbContext, IValidator<CreateAggregateCommand> validator)
{
    public async Task<long> CreateAggregate(CreateAggregateCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        var aggregate = new AggregateEntity
        {
            Name = command.Name
        };

        dbContext.Aggregates.Add(aggregate);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return aggregate.Id;
    }

    public async Task<AggregateEntity> GetAggregate(long id, CancellationToken cancellationToken)
    {
        var aggregate = await dbContext.Aggregates.FindAsync([id], cancellationToken);
            
        if (aggregate == null)
        {
            throw new InvalidOperationException($"Aggregate with id {id} not found");
        }

        return aggregate;
    }
}