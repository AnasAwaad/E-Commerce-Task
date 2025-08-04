using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.Auth.Commands.ConfirmEmail;
public class ConfirmEmailCommandHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<ConfirmEmailCommand>
{

	public async Task Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByEmailAsync(request.UserEmail);
		if (user == null)
			throw new NotFoundException("User", request.UserEmail);

		var decodedToken = Uri.UnescapeDataString(request.Token);
		var result = await userManager.ConfirmEmailAsync(user, decodedToken);

		if (!result.Succeeded)
			throw new Exception("Invalid email confirmation request.");
	}
}
