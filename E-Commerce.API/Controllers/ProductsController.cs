using E_Commerce.Application.Features.Products.Commands.CreateProduct;
using E_Commerce.Application.Features.Products.Queries.GetAllProducts;
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
		//TODO:
		return Ok(id);
		//return CreatedAtAction(nameof(GetById), new { id }, null);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery query)
	{
		return Ok(await mediator.Send(query));
	}

}
