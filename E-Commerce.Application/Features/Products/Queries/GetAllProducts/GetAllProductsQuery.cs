using E_Commerce.Application.Common;
using E_Commerce.Application.Features.Products.DTOs;
using E_Commerce.Domain.Constants;
using MediatR;

namespace E_Commerce.Application.Features.Products.Queries.GetAllProducts;
public class GetAllProductsQuery : IRequest<PagedResult<ProductDto>>
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public string? Search { get; set; }
	public string? SortBy { get; set; }
	public SortDirection SortDirection { get; set; }
}
