using E_Commerce.Domain.Constants;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Infrastructure.Data.Seeds;
public static class DefaultRoles
{
	public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
	{
		if (!roleManager.Roles.Any())
		{
			await roleManager.CreateAsync(new IdentityRole(AppRoles.Admin));
			await roleManager.CreateAsync(new IdentityRole(AppRoles.Customer));
		}
	}
}