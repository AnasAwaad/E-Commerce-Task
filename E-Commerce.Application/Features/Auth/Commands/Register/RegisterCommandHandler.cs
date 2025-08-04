using E_Commerce.Domain.Constants;
using E_Commerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.Auth.Commands.Register;
internal class RegisterCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<RegisterCommand>
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
			throw new InvalidOperationException($"Failed to create user: {errors}");
		}

		if (!await roleManager.RoleExistsAsync(AppRoles.Customer))
		{
			await roleManager.CreateAsync(new IdentityRole(AppRoles.Customer));
		}

		await userManager.AddToRoleAsync(user, AppRoles.Customer);
	}
}
