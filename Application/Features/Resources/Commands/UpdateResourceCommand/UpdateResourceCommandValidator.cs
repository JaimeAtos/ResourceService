using FluentValidation;

namespace Application.Features.Resources.Commands.UpdateResourceCommand;


public class UpdateResourceCommandValidator : AbstractValidator<UpdateResourceCommand>
{
    public UpdateResourceCommandValidator()
    {
        RuleFor(r => r.Id).NotEmpty().WithMessage("{PropertyName} cannot be empty");

        RuleFor(r => r.FullName).NotEmpty().WithMessage("{PropertyName} cannot be empty")
           .MaximumLength(80).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.WorkEmail).NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .Matches(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?").WithMessage("{PropertyName} must be a valid email address")
            .MaximumLength(120).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.PersonalEmail).NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .Matches(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?").WithMessage("{PropertyName} must be a valid email address")
            .MaximumLength(120).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.Phone).NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .Matches(@"[0-9]{10}").WithMessage("{PropertyName} must be a valid phone number")
            .MaximumLength(10).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.CurrentStateDescription).NotEmpty().WithMessage("{PropertyName} cannot be empty")
           .MaximumLength(30).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.CurrentPositionDescription).NotEmpty().WithMessage("{PropertyName} cannot be empty")
           .MaximumLength(120).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.LocationId).NotEmpty().WithMessage("{PropertyName} cannot be empty");

        RuleFor(r => r.CurrentPositionDescription).NotEmpty().WithMessage("{PropertyName} cannot be empty")
          .MaximumLength(120).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.NessieID).NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .Matches(@"[0-9]{8}").WithMessage("{PropertyName} must be a valid NessieId")
            .MaximumLength(8).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");

        RuleFor(r => r.CurrentClientName).NotEmpty().WithMessage("{PropertyName} cannot be empty")
          .MaximumLength(80).WithMessage("{PropertyName} must not exceed {MaxLength} characters of length");
    }
}
