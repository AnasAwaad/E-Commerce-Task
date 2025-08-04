using E_Commerce.Application.Features.Auth.Commands.Login;
using E_Commerce.Application.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IMediator _mediator;
	private readonly ILogger<AuthController> _logger;

	public AuthController(IMediator mediator, ILogger<AuthController> logger)
	{
		_mediator = mediator;
		_logger = logger;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterCommand command)
	{
		await _mediator.Send(command);
		return Ok();
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginCommand command)
	{
		var result = await _mediator.Send(command);

		return Ok(result);
	}
}