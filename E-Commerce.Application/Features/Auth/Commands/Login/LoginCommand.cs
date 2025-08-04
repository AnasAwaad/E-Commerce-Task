using E_Commerce.Application.Features.Auth.Commands.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.Auth.Commands.Login;
public class LoginCommand : IRequest<AuthResponseDto>
{
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
}
