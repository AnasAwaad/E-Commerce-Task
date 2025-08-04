
using FluentValidation;

namespace E_Commerce.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MinimumLength(3).WithMessage("Product name must be at least 3 characters.");

		RuleFor(x => x.Price)
			.GreaterThan(0).WithMessage("Price must be greater than zero.");

		RuleFor(x => x.CategoryId)
			.GreaterThan(0).WithMessage("Category is required.");

	}

}
