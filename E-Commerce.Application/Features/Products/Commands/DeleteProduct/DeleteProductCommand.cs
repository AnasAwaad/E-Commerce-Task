using MediatR;

namespace E_Commerce.Application.Features.Products.Commands.DeleteProduct;
public class DeleteProductCommand(int id) : IRequest
{
	public int Id { get; } = id;
}
