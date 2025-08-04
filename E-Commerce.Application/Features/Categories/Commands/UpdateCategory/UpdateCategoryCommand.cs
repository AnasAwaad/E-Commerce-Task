using MediatR;
using System.Text.Json.Serialization;

namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory;
public class UpdateCategoryCommand : IRequest
{
	[JsonIgnore]
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string? Description { get; set; }
}
