using E_Commerce.Application.Features.Categories.Commands.CreateCategory;
using E_Commerce.Application.Features.Categories.Commands.DeleteCategory;
using E_Commerce.Application.Features.Categories.Commands.UpdateCategory;
using E_Commerce.Application.Features.Categories.Queries.GetAllCategories;
using E_Commerce.Application.Features.Categories.Queries.GetCategoryById;
using E_Commerce.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = AppRoles.Admin)]
public class CategoriesController(IMediator mediator) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll() =>
		 Ok(await mediator.Send(new GetAllCategoriesQuery()));


	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute] int id) =>
		Ok(await mediator.Send(new GetCategoryByIdQuery(id)));


	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
	{
		var id = await mediator.Send(command);
		return CreatedAtAction(nameof(GetById), new { id }, null);
	}


	[HttpPut("{id}")]
	public async Task<IActionResult> Update([FromRoute] int id, UpdateCategoryCommand command)
	{
		command.Id = id;
		await mediator.Send(command);

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete([FromRoute] int id)
	{
		await mediator.Send(new DeleteCategoryCommand(id));

		return NoContent();
	}

}
