using MediatR;

namespace E_Commerce.Application.Features.Auth.Commands.ConfirmEmail;
public class ConfirmEmailCommand(string? userEmail, string? token) : IRequest
{
	public string? UserEmail { get; set; } = userEmail;
	public string? Token { get; set; } = token;
}
