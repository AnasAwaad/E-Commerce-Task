using AutoMapper;
using E_Commerce.Application.Features.Categories.DTOs;
using E_Commerce.Application.Interfaces;
using MediatR;

namespace E_Commerce.Application.Features.Categories.Queries.GetAllCategories;
internal class GetAllCategorysQueryHandler(IUnitOfWork unitOfWork,
	IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
	public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
	{
		var categories = await unitOfWork.Categories.GetAllAsync();

		return mapper.Map<IEnumerable<CategoryDto>>(categories);
	}

}
