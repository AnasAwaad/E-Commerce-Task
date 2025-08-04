using FluentValidation;

namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory;
public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
	public UpdateCategoryCommandValidator()
	{

		RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");

		RuleFor(x => x.Name)
			.NotEmpty()
			.MinimumLength(3).WithMessage("Category name must be at least 3 characters.");

	}
}
