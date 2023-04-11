using FluentValidation;

namespace Application.Features.ResourcesExtraSkills.CreateResourceExtraSkillsCommand
{
    public class CreateResourceExtraSkillsCommandValidator : AbstractValidator<CreateResourceExtraSkillsCommand>
    {
        public CreateResourceExtraSkillsCommandValidator()
        {

            RuleFor(r => r.Title).NotEmpty().WithMessage("{PropertyName} cannot be empty")
           .MaximumLength(80).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

            RuleFor(r => r.ResourceId).NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(r => r.ExperienceOveralTypeTag).NotEmpty().WithMessage("{PropertyName} cannot be empty")
           .MaximumLength(40).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

            RuleFor(r => r.BriefDescription).NotEmpty().WithMessage("{PropertyName} cannot be empty")
           .MaximumLength(60).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

            //TODO: Investigar como hacer funcionar fluent validation con byte types
            //RuleFor(r => r.Point).InclusiveBetween(0, 100);

            RuleFor(r => r.IsApproved).Must(r => r == false || r == true);
        }
    }
}
