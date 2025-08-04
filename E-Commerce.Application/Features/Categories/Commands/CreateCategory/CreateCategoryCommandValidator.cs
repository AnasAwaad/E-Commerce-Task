using FluentValidation;

namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory;
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
	public CreateCategoryCommandValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MinimumLength(3).WithMessage("Category name must be at least 3 characters.");

	}
}
