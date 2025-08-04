using FluentValidation;


namespace E_Commerce.Application.Features.Products.Commands.UpdateProduct;
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
	public UpdateProductCommandValidator()
	{
		RuleFor(x => x.Id)
			.NotNull().WithMessage("Product name is required.");

		RuleFor(x => x.Name)
			.NotNull().WithMessage("Product name is required.")
			.MinimumLength(3).WithMessage("Product name must be at least 3 characters.");

		RuleFor(x => x.Price)
			.GreaterThan(0).WithMessage("Price must be greater than zero.");

		RuleFor(x => x.CategoryId)
			.GreaterThan(0).WithMessage("Category is required.");

	}
}
