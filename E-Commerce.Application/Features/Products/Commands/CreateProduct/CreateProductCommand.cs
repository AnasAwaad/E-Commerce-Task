using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Features.Products.Commands.CreateProduct;
public class CreateProductCommand : IRequest<int>
{
	public string Name { get; set; } = null!;
	public decimal Price { get; set; }
	public string? Description { get; set; }
	public IFormFile? CoverImageFile { get; set; }
	public int CategoryId { get; set; }
}
