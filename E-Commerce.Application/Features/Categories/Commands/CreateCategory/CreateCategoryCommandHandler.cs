using AutoMapper;
using E_Commerce.Application.Features.Categories.Commands.CreateCategory;
using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Entities;
using MediatR;

namespace E_Commerce.Categories.Features.Categories.Commands.CreateCategory;
internal class CreateCategoryCommandHandler(IMapper mapper,
	IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand, int>
{
	public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
	{

		var category = mapper.Map<Category>(request);

		await unitOfWork.Categories.CreateAsync(category);
		await unitOfWork.SaveChangesAsync();

		return category.Id;

	}
}
