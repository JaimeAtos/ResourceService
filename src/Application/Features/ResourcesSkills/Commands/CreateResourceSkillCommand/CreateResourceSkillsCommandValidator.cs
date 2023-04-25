using FluentValidation;

namespace Application.Features.ResourcesSkills.Commands.CreateResourceSkillCommand;

public class CreateResourceSkillsCommandValidator : AbstractValidator<CreateResourceSkillsCommand>
{
    public CreateResourceSkillsCommandValidator()
    {
        RuleFor(r => r.ResourceId).NotEmpty().WithMessage("{PropertyName} cannot be empty");

        RuleFor(r => r.SkillName).NotEmpty().WithMessage("{PropertyName} cannot be empty")
           .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.SkillAcceptanceURL).NotEmpty().WithMessage("{PropertyName} cannot be empty")
           .Matches(@"^[-a-zA-Z0-9@:%_\+.~#?&//=]{2,256}\.[a-z]{2,4}\b(\/[-a-zA-Z0-9@:%_\+.~#?&//=]*)?$")
           .WithMessage("{PropertyName} must be a valid url");

        RuleFor(r => r.IsCompliance).Must(r => r == false || r == true);
    }
}
