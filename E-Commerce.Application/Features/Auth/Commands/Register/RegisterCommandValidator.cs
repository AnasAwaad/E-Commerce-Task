using FluentValidation;

namespace E_Commerce.Application.Features.Auth.Commands.Register;
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
	public RegisterCommandValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress().WithMessage("Invalid email format.");

		RuleFor(x => x.Password)
			.NotEmpty()
			.MinimumLength(6).WithMessage("Password must be at least 6 characters.");

		RuleFor(x => x.FullName)
			.NotEmpty()
			.MinimumLength(3).WithMessage("Full name must be at least 3 characters.");
	}
}