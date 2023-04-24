using FluentValidation;

namespace Application.Features.ResourcesExtraSkills.UpdateResourceExtraSkillsCommand;

public class UpdateResourceExtraSkillsCommandValidator : AbstractValidator<UpdateResourceExtraSkillsCommand>
{
	public UpdateResourceExtraSkillsCommandValidator()
	{
        RuleFor(r => r.Id).NotEmpty().WithMessage("{PropertyName} cannot be empty");

        RuleFor(r => r.Title).NotEmpty().WithMessage("{PropertyName} cannot be empty")
       .MaximumLength(80).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.ResourceId).NotEmpty().WithMessage("{PropertyName} cannot be empty");

        RuleFor(r => r.ExperienceOverallTypeTag).NotEmpty().WithMessage("{PropertyName} cannot be empty")
       .MaximumLength(40).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.BriefDescription).NotEmpty().WithMessage("{PropertyName} cannot be empty")
       .MaximumLength(60).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.IsApproved).Must(r => r == false || r == true);
    }
}
