using E_Commerce.Application.Features.Products.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.Products.Queries.GetProductById;
public class GetProductByIdQuery(int id) : IRequest<ProductDto>
{
	public int Id { get; } = id;
}
