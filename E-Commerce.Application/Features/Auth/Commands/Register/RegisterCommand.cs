using MediatR;

namespace E_Commerce.Application.Features.Auth.Commands.Register;
public class RegisterCommand : IRequest
{
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
	public string FullName { get; set; } = null!;
}
