using FluentValidation;

namespace Application.Features.ResourcesExtraSkills.DeleteResourceExtraSkillsCommand;

public class DeleteResourceExtraSkillsCommandValidator : AbstractValidator<DeleteResourceExtraSkillsCommand>
{
    public DeleteResourceExtraSkillsCommandValidator()
    {
        RuleFor(r => r.Id).NotEmpty().WithMessage("{PropertyName} cannot be empty");
    }
}
