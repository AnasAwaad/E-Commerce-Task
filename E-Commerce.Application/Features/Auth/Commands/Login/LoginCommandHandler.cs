using E_Commerce.Application.Features.Auth.Commands.DTOs;
using E_Commerce.Application.Interfaces.Services;
using E_Commerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.Auth.Commands.Login;
internal class LoginCommandHandler(UserManager<ApplicationUser> userManager,
	SignInManager<ApplicationUser> signInManager,
	ITokenService tokenService) : IRequestHandler<LoginCommand, AuthResponseDto>
{
	public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByEmailAsync(request.Email);
		if (user == null)
			throw new UnauthorizedAccessException("Invalid email or password.");

		var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
		if (!result.Succeeded)
			throw new UnauthorizedAccessException("Invalid email or password.");

		var role = await userManager.GetRolesAsync(user);
		var token = tokenService.GenerateToken(user, role.First());

		return new AuthResponseDto
		{
			Token = token,
			Email = user.Email!,
		};
	}
}
