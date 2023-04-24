using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ResourcesSkills.Commands.DeleteResourceSkillCommand;

public class DeleteResourceSkillsCommandValidator : AbstractValidator<DeleteResourceSkillsCommand>
{
    public DeleteResourceSkillsCommandValidator()
    {
        RuleFor(r => r.Id).NotEmpty().WithMessage("{PropertyName} cannot be empty");
    }
}
