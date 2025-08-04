using E_Commerce.Domain.Constants;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace E_Commerce.Application.Features.Auth.Commands.Register;
internal class RegisterCommandHandler(UserManager<ApplicationUser> userManager,
	RoleManager<IdentityRole> roleManager,
	IEmailSender emailSender) : IRequestHandler<RegisterCommand>
{
	public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
	{
		var user = new ApplicationUser
		{
			Email = request.Email,
			UserName = request.Email,
			FullName = request.FullName
		};


		var createResult = await userManager.CreateAsync(user, request.Password);
		if (!createResult.Succeeded)
		{
			var errors = string.Join("; ", createResult.Errors.Select(e => e.Description));
			throw new InvalidException($"Failed to create user: {errors}");
		}

		if (!await roleManager.RoleExistsAsync(AppRoles.Customer))
		{
			await roleManager.CreateAsync(new IdentityRole(AppRoles.Customer));
		}

		await userManager.AddToRoleAsync(user, AppRoles.Customer);

		await SendEmailToUser(user);

	}
	private async Task SendEmailToUser(ApplicationUser user)
	{
		var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

		var confirmationLink = $"https://localhost:7074/api/Auth/confirm-email?userEmail={user.Email}&token={Uri.EscapeDataString(token)}";

		await emailSender.SendEmailAsync(user.Email, "Confirm your email",
			$"""
                    <h2>Welcome, {user.FullName}!</h2>
                    <p>Click the link below to confirm your email:</p>
                    <a href="{confirmationLink}">Confirm Email</a>
                    """);
	}
}
