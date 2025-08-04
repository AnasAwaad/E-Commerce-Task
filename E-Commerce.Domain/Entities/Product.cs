namespace E_Commerce.Domain.Entities;
public class Product : BaseEntity
{
	public string Name { get; set; } = null!;
	public decimal Price { get; set; }
	public string? Description { get; set; }
	public string? CoverImageUrl { get; set; }
	public int CategoryId { get; set; }
	public Category Category { get; set; }
}
