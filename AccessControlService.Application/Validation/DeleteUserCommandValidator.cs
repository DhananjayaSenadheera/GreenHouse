using AccessControlService.Application.Requests.User.Commands.Delete;
using FluentValidation;

namespace AccessControlService.Application.Validation;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserComand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithMessage("Id cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("UserId Cannot be the default GUID");
    }
}