using FluentValidation;

namespace Application.Features.Resources.Commands.DeleteResourceCommand;


public class DeleteResourceCommandValidator : AbstractValidator<DeleteResourceCommand>
{
    public DeleteResourceCommandValidator()
    {
        RuleFor(r => r.Id).NotEmpty().WithMessage("{PropertyName} cannot be empty");
    }
}
