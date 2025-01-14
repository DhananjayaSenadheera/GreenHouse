using AccessControlService.Application.Requests.User.Commands.Create;
using FluentValidation;

namespace AccessControlService.Application.Validation;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        
        RuleFor(x => x.Fname)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(20).WithMessage("First name must be between 2 and 20 characters");
        
        RuleFor(x => x.Lname)
            .NotEmpty().WithMessage("Last name is required")
            .MaximumLength(20).WithMessage("Last name must be between 2 and 20 characters");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required")
            .MaximumLength(20).WithMessage("Password must be between 2 and 20 characters");
    }
}