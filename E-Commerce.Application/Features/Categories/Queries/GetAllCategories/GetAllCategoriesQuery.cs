using E_Commerce.Application.Features.Categories.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.Categories.Queries.GetAllCategories;
public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
}
