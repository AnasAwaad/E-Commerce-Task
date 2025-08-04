using AutoMapper;
using E_Commerce.Application.Features.Products.DTOs;
using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Exceptions;
using MediatR;

namespace E_Commerce.Application.Features.Products.Queries.GetProductById;
internal class GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductDto>
{
	public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
	{
		var product = await unitOfWork.Products.GetByIdWithCategory(request.Id);

		if (product is null)
			throw new NotFoundException(nameof(Product), request.Id.ToString());

		return mapper.Map<ProductDto>(product);
	}
}
