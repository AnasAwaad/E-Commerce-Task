using FluentValidation;

namespace E_Commerce.Application.Features.Auth.Commands.Login;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
	public LoginCommandValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress().WithMessage("Invalid email format.");

		RuleFor(x => x.Password)
			.NotEmpty()
			.MinimumLength(6).WithMessage("Password must be at least 6 characters.");
	}
}