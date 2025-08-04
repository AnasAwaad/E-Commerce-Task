using E_Commerce.Domain.Constants;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Infrastructure.Data.Seeds;

public static class DefaultUsers
{
	public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
	{
		var admin = new ApplicationUser
		{
			FullName = "Admin",
			Email = "Admin@gmail.com",
			UserName = "Admin@gmail.com",
			EmailConfirmed = true,
		};

		var customer = new ApplicationUser
		{
			FullName = "Customer",
			Email = "Customer@gmail.com",
			UserName = "Customer@gmail.com",
			EmailConfirmed = true,
		};

		var adminUser = await userManager.FindByNameAsync(admin.UserName);
		var customerUser = await userManager.FindByNameAsync(customer.UserName);

		if (adminUser is null)
		{
			await userManager.CreateAsync(admin, "Pa$$w0rd");
			await userManager.AddToRoleAsync(admin, AppRoles.Admin);
		}

		if (customerUser is null)
		{
			await userManager.CreateAsync(customer, "Pa$$w0rd");
			await userManager.AddToRoleAsync(customer, AppRoles.Customer);
		}
	}
}
