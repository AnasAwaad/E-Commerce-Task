using AutoMapper;
using E_Commerce.Application.Features.Categories.DTOs;
using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Exceptions;
using MediatR;

namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById;
internal class GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
	public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
	{
		var category = await unitOfWork.Categories.GetByIdAsync(request.Id);

		if (category is null)
			throw new NotFoundException(nameof(Category), request.Id.ToString());

		return mapper.Map<CategoryDto>(category);
	}
}
