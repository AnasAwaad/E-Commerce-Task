using AutoMapper;
using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Interfaces.Services;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Exceptions;
using MediatR;

namespace E_Commerce.Application.Features.Products.Commands.UpdateProduct;
internal class UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICloudinaryService cloudinaryService) : IRequestHandler<UpdateProductCommand>
{
	public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		var product = await unitOfWork.Products.GetByIdAsync(request.Id);

		if (product is null)
			throw new NotFoundException(nameof(Product), request.Id.ToString());

		var category = await unitOfWork.Categories.GetByIdAsync(request.CategoryId);
		if (category is null)
			throw new NotFoundException(nameof(Category), request.CategoryId.ToString());

		mapper.Map(request, product);


		if (request.CoverImageFile is not null)
		{
			string imageUrl = await cloudinaryService.UploadFileAsync(request.CoverImageFile, "Products");
			product.CoverImageUrl = imageUrl;
		}

		await unitOfWork.SaveChangesAsync();
	}
}
