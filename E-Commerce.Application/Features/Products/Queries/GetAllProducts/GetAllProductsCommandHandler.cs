using AutoMapper;
using E_Commerce.Application.Common;
using E_Commerce.Application.Features.Products.DTOs;
using E_Commerce.Application.Interfaces;
using MediatR;

namespace E_Commerce.Application.Features.Products.Queries.GetAllProducts;
internal class GetAllProductsQueryHandler(IUnitOfWork unitOfWork,
	IMapper mapper) : IRequestHandler<GetAllProductsQuery, PagedResult<ProductDto>>
{
	public async Task<PagedResult<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
	{
		var (totalCount, products) = await unitOfWork.Products.GetAllMatchingAsync(request.PageNumber, request.PageSize, request.Search, request.SortBy, request.SortDirection);

		var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);


		return new PagedResult<ProductDto>(productDtos, totalCount, request.PageNumber, request.PageSize);

	}

}
