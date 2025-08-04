using FluentValidation;

namespace E_Commerce.Application.Features.Auth.Commands.Register;
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
	public RegisterCommandValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Invalid email format.");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(6).WithMessage("Password must be at least 6 characters.");

		RuleFor(x => x.FullName)
			.NotEmpty().WithMessage("Full name is required.")
			.MinimumLength(3).WithMessage("Full name must be at least 3 characters.");
	}
}