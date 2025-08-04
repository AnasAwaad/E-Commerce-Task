using E_Commerce.Application.Features.Categories.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQuery(int id) : IRequest<CategoryDto>
{
	public int Id { get; } = id;
}
