using AutoMapper;
using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Exceptions;
using MediatR;

namespace E_Commerce.Application.Features.Products.Commands.DeleteProduct;
internal class DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteProductCommand>
{
	public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
	{
		var product = await unitOfWork.Products.GetByIdAsync(request.Id);

		if (product is null)
			throw new NotFoundException(nameof(Product), request.Id.ToString());

		unitOfWork.Products.Delete(product);
		await unitOfWork.SaveChangesAsync();
	}
}
