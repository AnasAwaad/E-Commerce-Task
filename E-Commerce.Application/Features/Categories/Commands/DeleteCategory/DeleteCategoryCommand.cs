using MediatR;

namespace E_Commerce.Application.Features.Categories.Commands.DeleteCategory;
public class DeleteCategoryCommand(int id) : IRequest
{
	public int Id { get; } = id;
}
