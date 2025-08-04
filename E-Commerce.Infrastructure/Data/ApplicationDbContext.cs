using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace E_Commerce.Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
