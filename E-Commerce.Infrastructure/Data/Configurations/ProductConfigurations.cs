using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Data.Configurations;
internal class ProductConfigurations : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.Property(p => p.Name)
			.IsRequired()
			.HasMaxLength(200);

		builder.Property(p => p.Description)
			.HasMaxLength(1000);

		builder.Property(p => p.CoverImageUrl)
			   .HasMaxLength(4000);

		builder.Property(p => p.Price)
			.IsRequired()
			.HasColumnType("decimal(18,2)");
	}
}
