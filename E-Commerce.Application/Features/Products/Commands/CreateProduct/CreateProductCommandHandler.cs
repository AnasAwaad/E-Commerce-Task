using AutoMapper;
using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Interfaces.Services;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Exceptions;
using MediatR;

namespace E_Commerce.Application.Features.Products.Commands.CreateProduct;
internal class CreateProductCommandHandler(IMapper mapper,
	IUnitOfWork unitOfWork,
	ICloudinaryService cloudinaryService) : IRequestHandler<CreateProductCommand, int>
{
	public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{

		var category = await unitOfWork.Categories.GetByIdAsync(request.CategoryId);
		if (category is null)
			throw new NotFoundException(nameof(Category), request.CategoryId.ToString());

		var product = mapper.Map<Product>(request);
		if (request.CoverImageFile is not null)
		{
			var fileUrl = await cloudinaryService.UploadFileAsync(request.CoverImageFile, "Products");
			product.CoverImageUrl = fileUrl;
		}

		await unitOfWork.Products.CreateAsync(product);
		await unitOfWork.SaveChangesAsync();

		return product.Id;

	}
}
