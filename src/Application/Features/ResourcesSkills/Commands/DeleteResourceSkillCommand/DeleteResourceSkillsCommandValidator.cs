﻿using FluentValidation;

namespace Application.Features.ResourcesSkills.Commands.DeleteResourceSkillCommand;

public class DeleteResourceSkillsCommandValidator : AbstractValidator<DeleteResourceSkillsCommand>
{
    public DeleteResourceSkillsCommandValidator()
    {
        RuleFor(r => r.Id).NotEmpty().WithMessage("{PropertyName} cannot be empty");
    }
}
