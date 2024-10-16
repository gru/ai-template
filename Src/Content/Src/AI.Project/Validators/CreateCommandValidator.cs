﻿using AI.Project.Http.Contracts;
using FluentValidation;

namespace AI.Project.Validators;

public class CreateCommandValidator : AbstractValidator<CreateAggregateCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(5, 150).WithMessage("Name must be between 5 and 150 characters.");
    }
}