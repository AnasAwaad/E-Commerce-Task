using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Data.Configurations;
internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name)
			   .IsRequired()
			   .HasMaxLength(200);

		builder.Property(c => c.Description)
			   .HasMaxLength(1000);

		builder.HasMany(c => c.Products)
			.WithOne(p => p.Category)
			.HasForeignKey(p => p.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

	}
}
