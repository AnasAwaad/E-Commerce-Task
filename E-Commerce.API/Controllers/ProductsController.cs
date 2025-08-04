using E_Commerce.Application.Features.Products.Commands.CreateProduct;
using E_Commerce.Application.Features.Products.Commands.DeleteProduct;
using E_Commerce.Application.Features.Products.Commands.UpdateProduct;
using E_Commerce.Application.Features.Products.Queries.GetAllProducts;
using E_Commerce.Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
	[HttpPost]
	public async Task<IActionResult> Create([FromForm] CreateProductCommand command)
	{
		var id = await mediator.Send(command);
		return CreatedAtAction(nameof(GetById), new { id }, null);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery request)
	{
		return Ok(await mediator.Send(request));
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute] int id)
	{
		return Ok(await mediator.Send(new GetProductByIdQuery(id)));
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateProductCommand command)
	{
		command.Id = id;
		await mediator.Send(command);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete([FromRoute] int id)
	{
		await mediator.Send(new DeleteProductCommand(id));
		return NoContent();
	}

}
