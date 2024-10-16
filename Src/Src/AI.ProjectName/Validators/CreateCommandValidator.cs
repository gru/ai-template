using AI.ProjectName.Http.Contracts;
using FluentValidation;

namespace AI.ProjectName.Validators;

/// <summary>
/// Validator for the CreateAggregateCommand.
/// </summary>
public class CreateCommandValidator : AbstractValidator<CreateAggregateCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCommandValidator class.
    /// Sets up validation rules for the CreateAggregateCommand.
    /// </summary>
    public CreateCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(5, 150).WithMessage("Name must be between 5 and 150 characters.");
    }
}